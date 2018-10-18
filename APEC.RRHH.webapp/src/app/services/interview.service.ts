import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CandidateInterview } from '../models/candidate-interview';
import { Job } from '../models/job';

@Injectable()
export class InterviewService {
    constructor(private http: HttpClient) {
    }

    create(candidateInterview: CandidateInterview): Promise<CandidateInterview> {
        return this.http.post<CandidateInterview>(`${environment.apecRRHHApiUrl}/candidates/interviews`, candidateInterview)
        .toPromise();
    }

    contractCandidate(interviewId, monthlySalary): Promise<Job> {
        return this.http.post<Job>(`${environment.apecRRHHApiUrl}/candidates/interviews/${interviewId}/contract`,
         {interviewId, monthlySalary})
        .toPromise();
    }

    getInterviewHistory(): Promise<CandidateInterview[]> {
        return this.http.get<CandidateInterview[]>(`${environment.apecRRHHApiUrl}/candidates/interviews/history`)
        .toPromise();
    }
}
