import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Job } from '../models/job';
import { Employee } from '../models/employee';
import { CandidateEmployeeAspiratedJob } from '../models/candidate-employee-aspirated-job';

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

    aspirateToJob(aspirateToJob: CandidateEmployeeAspiratedJob): Promise<BasicOperationResult<CandidateEmployeeAspiratedJob>> {
        // tslint:disable-next-line:max-line-length
        return this.http.post<BasicOperationResult<CandidateEmployeeAspiratedJob>>(`${environment.apecRRHHApiUrl}/candidates/${aspirateToJob.id}/aspirate`,
            aspirateToJob)
            .toPromise();
    }

    getAllAspirations(): Promise<CandidateEmployeeAspiratedJob[]> {
        return this.http.get<CandidateEmployeeAspiratedJob[]>(`${environment.apecRRHHApiUrl}/candidates/aspiration-jobs`)
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
