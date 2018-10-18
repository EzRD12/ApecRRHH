import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Job } from '../models/job';
import { Employee } from '../models/employee';

@Injectable()
export class JobService {
    constructor(private http: HttpClient) {
    }

    create(job: Job): Promise<Job> {
        return this.http.post<Job>(`${environment.apecRRHHApiUrl}/jobs`, job)
        .toPromise();
    }

    changeJobStatus(jobId): Promise<Job> {
        return this.http.patch<Job>(`${environment.apecRRHHApiUrl}/jobs/${jobId}/status`, {})
        .toPromise();
    }


    getAllJobs(): Promise<Job[]> {
        return this.http.get<Job[]>(`${environment.apecRRHHApiUrl}/jobs`)
        .toPromise();
    }

    getJob(jobId): Promise<Job> {
        return this.http.get<Job>(`${environment.apecRRHHApiUrl}/jobs/${jobId}`)
        .toPromise();
    }

    getJobEmployees(jobId): Promise<Employee[]> {
        return this.http.get<Employee[]>(`${environment.apecRRHHApiUrl}/jobs/${jobId}/employees`)
        .toPromise();
    }
}
