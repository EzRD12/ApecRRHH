import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Employee } from '../models/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {

  displayData: any[] = [];
  isDataLoading = true;
  employees: Employee[] = [];
  employeeSelected: Employee;
  detailForm: FormGroup;
  employeesHeaders = ['Nombre', 'Correo electronico', 'Identificacion', 'Rol', 'Puesto actual', 'Fecha de ingreso', 'Estado'];
  modalVisibility = false;

  constructor(private employeeService: EmployeeService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.detailForm = this.formBuilder.group({});
    this.employeeService.getAllEmployees().then((data) => {
      this.isDataLoading = false;
      this.employees = data;
      this.displayData = this.employees.map((employee) => {
        return this.buildDisplayData(employee);
      });
    });
  }

  private buildDisplayData(employee: Employee) {
    return {
      id: employee.id,
      name: employee.user.fullName,
      email: employee.user.email,
      identification: employee.user.identification,
      role: employee.user.currentRole,
      currentJob: employee.job.name,
      admissionDate: employee.admissionDate,
      status: employee.status
    };
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  getEmployeeDetail(employeeId) {
    this.employeeSelected = this.employees.find(employee => employee.id === employeeId);
    this.changeModalVisibility(true);
  }

  changeStatusEmployee(employeeId) {
    this.employeeService.changeStatusEmployee(employeeId).then(employee => {
      this.employees.forEach(data => data.status = data.id === employee.id ? employee.status : data.status);
      this.displayData.forEach(data => data.status = data.id === employee.id ? employee.status : data.status);
    });
  }

  giveMeReport() {
    window.print();
  }

}
