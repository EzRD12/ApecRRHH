import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';
import { CandidateEmployeeAspiratedJob } from '../../models/candidate-employee-aspirated-job';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastNotificationService, ToastType } from '../../services/toast-notification.service';
import { InterviewService } from '../../services/interview.service';
import { DashboardService } from '../../services/dashboard.service';
import { Employee } from '../../models/employee';
import * as moment from 'moment';

@Component({
  selector: 'app-requested',
  templateUrl: './requested.component.html',
  styleUrls: ['./requested.component.css']
})
export class RequestedComponent implements OnInit {

  aspirationsToJob: CandidateEmployeeAspiratedJob[] = [];
  aspiratorSelected: CandidateEmployeeAspiratedJob;
  aspirationsToJobHeaders = ['Candidato', 'Recomendado por', 'Puesto apostado', 'Salario aspirado'];
  createInterviewForm: FormGroup;
  modalVisibility = false;
  employees: Employee[] = [];
  isConfirmLoading = false;
  isDataLoading = true;

  constructor(private jobService: JobService,
    private formBuilder: FormBuilder,
    private toastNotificationService: ToastNotificationService,
    private interviewService: InterviewService,
    private dashboardService: DashboardService) { }

  ngOnInit() {
    this.buildForm();
    this.jobService.getAllAspirations().then(data => {
      this.isDataLoading = false;
      this.aspirationsToJob = data;
    });
    this.dashboardService.getAllEmployees().then(data => {
      this.employees = data;
    });
  }

  buildForm() {
    this.createInterviewForm = this.formBuilder.group({
      interviewDate: ['', [Validators.required]],
      employeeIdWhoInterviewed: ['', Validators.required]
    });
  }

  setAspiratorSelected(aspirator) {
    this.aspiratorSelected = aspirator;
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createInterview() {
    const interview = this.createInterviewForm.getRawValue();
    if (moment(interview.interviewDate).isBefore(moment(new Date()).toDate())) {
      this.displayToast('Error', 'La entrevista no puede ser asignada para el pasado', ToastType.Error);
      return;
    }
    this.isConfirmLoading = true;

    interview.candidateEmployeeId = this.aspiratorSelected.candidateEmployeeId;
    interview.candidateEmployeeAspiratedJobId = this.aspiratorSelected.id;
    interview.jobId = this.aspiratorSelected.jobId;
    interview.employeeNotes = '';
    interview.hired = false;
    this.interviewService.create(interview).then(() => {
      this.displayToast('Exito', 'La entrevista fue pautada con exito', ToastType.Success);
      this.aspirationsToJob = this.aspirationsToJob.filter(aspiration => aspiration.id === this.aspiratorSelected.id);
      this.aspirationsToJob = [...this.aspirationsToJob];
      this.isConfirmLoading = false;
      this.changeModalVisibility(false);
    }).catch((error) => {
      this.displayToast('Error', error.message, ToastType.Error);
    });
  }

  displayToast(title: string, message: string, toastType: ToastType): void {
    this.toastNotificationService.show({
      title: title,
      message: message
    }, toastType);
  }

}
