import { Component, OnInit } from '@angular/core';
import { Vacancies } from '../../models/vacancies';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-candidate-active',
  templateUrl: './candidate-active.component.html',
  styleUrls: ['./candidate-active.component.css']
})
export class CandidateActiveComponent implements OnInit {

  candidateEmployeesHeaders = ['Nombre completo', 'Correo Electronico', 'Cantidad preparaciones', 'Cantidad lenguajes'];
  isVacanciesLoading = true;
  userCandidateEmployees: any[] = [];

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
    this.dashboardService.getCandidateEmployeesActives().then(data => {
      this.userCandidateEmployees = data.map((candidate) => {
        return {
          id: candidate.id,
          fullName: candidate.user.fullName,
          email: candidate.user.email,
          preparationsHandle: candidate.user.preparations.length,
          languagesHandle: candidate.user.languages.length
        };
      });
    });
  }

}
