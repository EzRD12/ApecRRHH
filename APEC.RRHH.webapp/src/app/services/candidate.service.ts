import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { CandidateEmployeeAspiratedJob } from '../models/candidate-employee-aspirated-job';

@Injectable()
export class CandidateService {
    constructor(private http: HttpClient) {
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
}
