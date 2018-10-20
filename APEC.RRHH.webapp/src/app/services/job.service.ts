import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { CandidateEmployee } from '../models/candidate-employee';
import { CandidateEmployeeAspiratedJob } from '../models/candidate-employee-aspirated-job';
import { Employee } from '../models/employee';
import { Job } from '../models/job';

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
        return this.http.post<BasicOperationResult<CandidateEmployeeAspiratedJob>>(`${environment.apecRRHHApiUrl}/candidates/${aspirateToJob.candidateEmployeeId}/aspirate`,
            aspirateToJob)
            .toPromise();
    }

    getAllAspirations(): Promise<CandidateEmployeeAspiratedJob[]> {
        return this.http.get<CandidateEmployeeAspiratedJob[]>(`${environment.apecRRHHApiUrl}/candidates/aspiration-jobs`)
            .toPromise();
    }

    getCandidateByUserId(userId): Promise<CandidateEmployee> {
        return this.http.get<CandidateEmployee>(`${environment.apecRRHHApiUrl}/candidates/${userId}`)
            .toPromise();
    }

    getAspirationsToJob(): Promise<CandidateEmployeeAspiratedJob[]> {
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
