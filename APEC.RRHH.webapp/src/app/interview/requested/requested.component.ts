import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';
import { CandidateEmployeeAspiratedJob } from '../../models/candidate-employee-aspirated-job';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastNotificationService } from '../../services/toast-notification.service';

@Component({
  selector: 'app-requested',
  templateUrl: './requested.component.html',
  styleUrls: ['./requested.component.css']
})
export class RequestedComponent implements OnInit {

  aspirationsToJob: CandidateEmployeeAspiratedJob[] = [];
  aspirationsToJobHeaders = ['Candidato', 'Recomendado por', 'Puesto apostado', 'Salario aspirado'];
  createInterviewForm: FormGroup;

  constructor(private jobService: JobService,
    private formBuilder: FormBuilder,
    private toastNotificationService: ToastNotificationService) { }

  ngOnInit() {
    this.buildForm();
    this.jobService.getAllAspirations().then(data => {
      console.log(data);
      this.aspirationsToJob = data;
    });
  }

  buildForm() {
    this.createInterviewForm = this.formBuilder.group({
      interviewDate: ['', [Validators.required]],
      interviewer: ['', Validators.required]
    });
  }

  createInterview() {
    const interview = this.createInterviewForm.getRawValue();
  }

}
