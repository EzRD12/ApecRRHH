import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Departament } from '../models/departament';

@Injectable()
export class DepartamentService {
    constructor(private http: HttpClient) {
    }

    create(description: string): Promise<BasicOperationResult<Departament>> {
        const request = { description, status: FeatureStatus.enabled };
        return this.http.post<BasicOperationResult<Departament>>(`${environment.apecRRHHApiUrl}/departaments`, request)
        .toPromise();
    }

    getAllDepartaments(): Promise<Departament[]> {
        return this.http.get<Departament[]>(`${environment.apecRRHHApiUrl}/departaments`)
        .toPromise();
    }
}
