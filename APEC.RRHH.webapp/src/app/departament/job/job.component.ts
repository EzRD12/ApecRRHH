import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../../models/employee';
import { JobService } from '../../services/job.service';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})
export class JobComponent implements OnInit {

  employees: Employee[] = [];
  jobId: string;
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
  }

  changeStatusEmployee(employeeId) {
    console.log(employeeId);
    this.employeeService.changeStatusEmployee(employeeId).then( employee => {
      this.employees.forEach( data => data.status = data.id === employee.id ? employee.status : data.status);
    });
  }

}
