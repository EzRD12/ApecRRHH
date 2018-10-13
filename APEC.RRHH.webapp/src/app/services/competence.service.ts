import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Competence } from '../models/competence';

@Injectable()
export class CompetenceService {
    constructor(private http: HttpClient) {
    }

    create(description: string): Promise<BasicOperationResult<Competence>> {
        const request = { description, status: FeatureStatus.enabled };
        return this.http.post<BasicOperationResult<Competence>>(`${environment.apecRRHHApiUrl}/configuration/competence`, request)
        .toPromise();
    }

    getAllCompetences(): Promise<BasicOperationResult<Competence[]>> {
        return this.http.get<BasicOperationResult<Competence[]>>(`${environment.apecRRHHApiUrl}/configuration/competence`)
        .toPromise();
    }
}
