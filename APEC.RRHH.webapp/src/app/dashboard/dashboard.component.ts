import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { Employee } from '../models/employee';
import { Job } from '../models/job';
import { UserProfile } from '../models/user-profile';
import { Vacancies } from '../models/vacancies';
import { AccountService } from '../services/account.service';
import { DashboardService } from '../services/dashboard.service';
import { JobService } from '../services/job.service';
import { ToastNotificationService, ToastType } from '../services/toast-notification.service';

@Component({
  selector: 'dashboard-cmp',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css']
})

export class DashboardComponent implements OnInit {

  currentUser: UserProfile;
  vacancies: Vacancies[] = [];
  jobs: Job[] = [];
  employees: Employee[] = [];
  userCandidateEmployees: any[] = [];
  candidateInterviews: any[] = [];
  isVacanciesLoading = true;
  quantityOfVacancies = 0;
  vacanciesHeaders = ['Nombre', 'Riesgo', 'Salario minimo', 'Salario maximo', 'Tipo moneda'];
  jobsHeaders = ['Nombre', 'Riesgo', 'Personal actual', 'Personal requerido'];
  candidateInterviewsHeaders = ['Candidato', 'Entrevistador', 'Fecha', 'Puesto apostado'];
  candidateEmployeesHeaders = ['Nombre completo', 'Correo Electronico', 'Cantidad preparaciones', 'Cantidad lenguajes'];
  isSearchLoading = false;
  searchChange$ = new BehaviorSubject('');
  aspirateToJobForm: FormGroup;
  vacancieSelected: Job;
  aspireToJobmodalVisibility = false;

  constructor(private dashboardService: DashboardService,
    private accountService: AccountService,
    private candidateService: JobService,
    private formBuilder: FormBuilder,
    private toastNotificationService: ToastNotificationService) { }

  ngOnInit() {
    this.currentUser = this.accountService.currentUser;

    this.buildAspirateJobForm();

    this.dashboardService.getVacanciesAvailables().then(data => {
      this.isVacanciesLoading = false;
      this.vacancies = data;
      data.map(vacancie => this.quantityOfVacancies = this.quantityOfVacancies + vacancie.quantityOfEmployeesNeeded);
    });

    this.dashboardService.getJobActives().then(data => {
      this.jobs = data;
    });

    this.dashboardService.getAllEmployees().then(data => {
      this.employees = data;
    });

    this.getCandidateEmployeeActives();

    this.getCandidateEmployeeOnAcceptationProcess();
  }

  private getCandidateEmployeeOnAcceptationProcess() {
    this.dashboardService.getCandidateEmployeesOnAcceptationProcess().then(data => {
      this.candidateInterviews = data.map((interview) => {
        return {
          candidateFullName: interview.candidateEmployee.user.fullName,
          interviewer: interview.employee.user.fullName,
          interviewDate: interview.interviewDate,
          jobName: interview.job.name
        };
      });
    });
  }

  private getCandidateEmployeeActives() {
    this.dashboardService.getCandidateEmployeesActives().then(data => {
      this.userCandidateEmployees = data.map((candidate) => {
        return {
          fullName: candidate.user.fullName,
          email: candidate.user.email,
          preparationsHandle: candidate.user.preparations.length,
          languagesHandle: candidate.user.languages.length
        };
      });
    });
  }

  buildAspirateJobForm() {
    this.aspirateToJobForm = this.formBuilder.group({
      salaryToAspire: ['', [Validators.required]],
      userIdWhoRecommendedIt: ['', Validators.required]
    });
  }

  setVacancieSelected(vacancie) {
    this.vacancieSelected = vacancie;
  }

  changeAspireToJobModalVisibility(visibility) {
    this.aspireToJobmodalVisibility = visibility;
  }

  aspirateToJob() {
    const currentUser = this.accountService.currentUser;
    let userHasAllRequerimentsForJob = true;
    for (const competence of this.vacancieSelected.competences) {
      if (!currentUser.competences.some(userCompetence => userCompetence.id === competence.id)) {
        this.displayToast('Lo sentimos', 'No posee las competencias requeridas para este puesto', ToastType.Info);
        this.changeAspireToJobModalVisibility(false);
        userHasAllRequerimentsForJob = false;
        break;
      }
    }

    for (const language of this.vacancieSelected.languages) {
      if (!currentUser.languages.some(userCompetence => userCompetence.id === language.id)) {
        this.displayToast('Lo sentimos', 'No maneja los idiomas requeridos para este puesto', ToastType.Info);
        this.changeAspireToJobModalVisibility(false);
        userHasAllRequerimentsForJob = false;
        break;
      }
    }

    if (!userHasAllRequerimentsForJob) {
      return;
    }

    this.candidateService.getCandidateByUserId(currentUser.id).then((candidate) => {
      const aspirateJob = this.aspirateToJobForm.getRawValue();
      aspirateJob.candidateEmployeeId = candidate.id;
      aspirateJob.jobId = this.vacancieSelected.id;
      this.candidateService.aspirateToJob(aspirateJob).then((result) => {
        if (result.success) {
          this.buildAspirateJobForm();
          this.displayToast('Exito', 'La operacion fue un exito', ToastType.Success);
        } else {
          this.displayToast('Ha ocurrido un error', result.message, ToastType.Success);
        }
        this.changeAspireToJobModalVisibility(false);
      }).catch((error) => {
        this.changeAspireToJobModalVisibility(false);
        this.displayToast('Ha ocurrido un error', error.error.message, ToastType.Error);
      });
    });
  }

  displayToast(title: string, message: string, toastType: ToastType): void {
    this.toastNotificationService.show({
      title: title,
      message: message
    }, toastType);
  }
}
