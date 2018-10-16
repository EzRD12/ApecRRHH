import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Language } from '../models/language';

@Injectable()
export class LanguageService {
    constructor(private http: HttpClient) {
    }

    create(description: string): Promise<BasicOperationResult<Language>> {
        const request = { name: description, status: FeatureStatus.enabled };
        return this.http.post<BasicOperationResult<Language>>(`${environment.apecRRHHApiUrl}/configuration/languages`, request)
        .toPromise();
    }

    getAllLanguages(): Promise<BasicOperationResult<Language[]>> {
        return this.http.get<BasicOperationResult<Language[]>>(`${environment.apecRRHHApiUrl}/configuration/languages`)
        .toPromise();
    }

    getLanguagesAvailables(): Promise<BasicOperationResult<Language[]>> {
        return this.http.get<BasicOperationResult<Language[]>>(`${environment.apecRRHHApiUrl}/configuration/languages/availables`)
        .toPromise();
    }

    changesLanguageStatus(languageId): Promise<BasicOperationResult<Language>> {
        // tslint:disable-next-line:max-line-length
        return this.http.patch<BasicOperationResult<Language>>(`${environment.apecRRHHApiUrl}/configuration/languages/${languageId}/status`, {})
        .toPromise();
    }
}
