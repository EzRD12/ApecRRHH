import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Competence } from '../models/competence';
import { Language } from '../models/language';

@Injectable()
export class LanguageService {
    constructor(private http: HttpClient) {
    }

    create(description: string): Promise<BasicOperationResult<Language>> {
        const request = { description, status: FeatureStatus.enabled };
        return this.http.post<BasicOperationResult<Language>>(`${environment.apecRRHHApiUrl}/configuration/language`, request)
        .toPromise();
    }

    getAllLanguages(): Promise<BasicOperationResult<Language[]>> {
        return this.http.get<BasicOperationResult<Language[]>>(`${environment.apecRRHHApiUrl}/configuration/language`)
        .toPromise();
    }
}
