import { Component, OnInit } from '@angular/core';
import { DashboardService } from '../../services/dashboard.service';

@Component({
  selector: 'app-pending',
  templateUrl: './pending.component.html',
  styleUrls: ['./pending.component.css']
})
export class PendingComponent implements OnInit {

  candidateInterviewsHeaders = ['Candidato', 'Entrevistador', 'Fecha', 'Puesto apostado'];
  candidateInterviews: any[] = [];

  constructor(private dashboardService: DashboardService) { }

  ngOnInit() {
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
