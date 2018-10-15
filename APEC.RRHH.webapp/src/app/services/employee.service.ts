import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Employee } from '../models/employee';

@Injectable()
export class EmployeeService {
    constructor(private http: HttpClient) {
    }

    create(employee: Employee): Promise<BasicOperationResult<Employee>> {
        return this.http.post<BasicOperationResult<Employee>>(`${environment.apecRRHHApiUrl}/employees`, employee)
        .toPromise();
    }

    getAllEmployees(): Promise<Employee[]> {
        return this.http.get<Employee[]>(`${environment.apecRRHHApiUrl}/employees`)
        .toPromise();
    }

    getEmployee(employeeId): Promise<Employee> {
        return this.http.get<Employee>(`${environment.apecRRHHApiUrl}/employees/${employeeId}`)
        .toPromise();
    }

    changeStatusEmployee(employeeId): Promise<Employee> {
        return this.http.patch<Employee>(`${environment.apecRRHHApiUrl}/employees/${employeeId}`, {})
        .toPromise();
    }
}
