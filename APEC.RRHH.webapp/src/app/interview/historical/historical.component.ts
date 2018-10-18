import { Component, OnInit } from '@angular/core';
import { InterviewService } from '../../services/interview.service';

@Component({
  selector: 'app-historical',
  templateUrl: './historical.component.html',
  styleUrls: ['./historical.component.css']
})
export class HistoricalComponent implements OnInit {

  candidateInterviewsHeaders = ['Candidato', 'Entrevistador', 'Fecha', 'Puesto apostado', 'Salario apostado', 'Resultado'];
  candidateInterviews: any[] = [];

  constructor(private interviewService: InterviewService) { }

  ngOnInit() {
    this.interviewService.getInterviewHistory().then(data => {
      this.candidateInterviews = data.map((interview) => {
        return {
          candidateFullName: interview.candidateEmployee.user.fullName,
          interviewer: interview.employee.user.fullName,
          interviewDate: interview.interviewDate,
          jobName: interview.job.name,
          salaryAspired: interview.candidateEmployeeAspiratedJob.salaryToAspire,
          hired: interview.hired
        };
      });
    });
  }

}
