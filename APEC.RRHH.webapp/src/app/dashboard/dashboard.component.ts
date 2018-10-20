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

  aspirateToJob() {
    const aspirateJob = this.aspirateToJobForm.getRawValue();
    aspirateJob.candidateEmployeeId = 1;
    aspirateJob.jobId = this.vacancieSelected.id;

    this.candidateService.aspirateToJob(aspirateJob).then((result) => {
      if (result.success) {
        this.displayToast('Exito', 'La operacion fue un exito', ToastType.Success);
      } else {
        this.displayToast('Ha ocurrido un error', result.message, ToastType.Success);
      }
    }).catch((error) => {
      this.displayToast('Ha ocurrido un error', error.error.message, ToastType.Success);
    });
  }

  onSearch(value: string): void {
    this.isSearchLoading = true;
    this.searchChange$.next(value);
  }

  displayToast(title: string, message: string, toastType: ToastType): void {
    this.toastNotificationService.show({
      title: title,
      message: message
    }, toastType);
  }
}
