import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CandidateEmployee } from '../models/candidate-employee';
import { Employee } from '../models/employee';
import { Job } from '../models/job';
import { Vacancies } from '../models/vacancies';
import { CandidateInterview } from '../models/candidate-interview';

/**
 * Implements the authentication functionality
 *
 * @export
 */
@Injectable()
export class DashboardService {
    constructor(private http: HttpClient) {
    }

    getVacanciesAvailables(): Promise<Vacancies[]> {
        return this.http.get<Vacancies[]>(`${environment.apecRRHHApiUrl}/dashboard/vacancies`)
            .toPromise();
    }

    getAllEmployees(): Promise<Employee[]> {
        return this.http.get<Employee[]>(`${environment.apecRRHHApiUrl}/dashboard/employees`)
            .toPromise();
    }

    getJobActives(): Promise<Job[]> {
        return this.http.get<Job[]>(`${environment.apecRRHHApiUrl}/dashboard/jobs`)
            .toPromise();
    }

    getCandidateEmployeesActives(): Promise<CandidateEmployee[]> {
        return this.http.get<CandidateEmployee[]>(`${environment.apecRRHHApiUrl}/dashboard/candidates`)
            .toPromise();
    }

    getCandidateEmployeesOnAcceptationProcess(): Promise<CandidateInterview[]> {
        return this.http.get<CandidateInterview[]>(`${environment.apecRRHHApiUrl}/dashboard/candidate-on-process`)
            .toPromise();
    }

}
