import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { FeatureStatus } from '../enums/feature-status';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { Departament } from '../models/departament';
import { Job } from '../models/job';

@Injectable()
export class DepartamentService {
    constructor(private http: HttpClient) {
    }

    create(name: string): Promise<Departament> {
        const request = { name, status: FeatureStatus.enabled };
        return this.http.post<Departament>(`${environment.apecRRHHApiUrl}/departaments`, request)
        .toPromise();
    }

    getAllDepartaments(): Promise<Departament[]> {
        return this.http.get<Departament[]>(`${environment.apecRRHHApiUrl}/departaments`)
        .toPromise();
    }

    getDepartament(departamentId): Promise<Departament> {
        return this.http.get<Departament>(`${environment.apecRRHHApiUrl}/departaments/${departamentId}`)
        .toPromise();
    }

    getDepartamentJobs(departamentId): Promise<Job[]> {
        return this.http.get<Job[]>(`${environment.apecRRHHApiUrl}/departaments/${departamentId}/jobs`)
        .toPromise();
    }
}
