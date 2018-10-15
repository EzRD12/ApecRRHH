import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Job } from '../models/job';

@Injectable()
export class JobService {
    constructor(private http: HttpClient) {
    }

    create(job: Job): Promise<BasicOperationResult<Job>> {
        return this.http.post<BasicOperationResult<Job>>(`${environment.apecRRHHApiUrl}/jobs`, job)
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
}
