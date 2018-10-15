import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { Job } from '../models/job';
import { Vacancies } from '../models/vacancies';
import { DashboardService } from '../services/dashboard.service';

@Component({
  selector: 'dashboard-cmp',
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.css']
})

export class DashboardComponent implements OnInit {

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
  constructor(private dashboardService: DashboardService) {

  }
  ngOnInit() {
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
}
