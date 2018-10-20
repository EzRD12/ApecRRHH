import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../models/employee';
import { JobService } from '../../services/job.service';
import { EmployeeService } from '../../services/employee.service';
import { Job } from '../../models/job';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})
export class JobComponent implements OnInit {

  employees: Employee[] = [];
  jobId: string;
  job: Job;
  jobName: string;
  employeesHeaders = ['Nombre completo', 'Correo', 'Fecha de registro', 'Salario mensual', 'Tipo de moneda', 'Estado'];

  constructor(private jobService: JobService,
              private activatedRoute: ActivatedRoute,
              private employeeService: EmployeeService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(parameters => {
      this.jobId = parameters.jobId;
    });

    this.jobService.getJobEmployees(this.jobId).then( data => {
      this.employees = data;
    });

    this.jobService.getJob(this.jobId).then( data => {
      this.job = data;
      this.jobName = this.job.name;
    });
  }

  changeStatusEmployee(employeeId) {
    this.employeeService.changeStatusEmployee(employeeId).then( employee => {
      this.employees.forEach( data => data.status = data.id === employee.id ? employee.status : data.status);
    });
  }

}
