import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { BasicOperationResult } from '../interfaces/basic-operation-result';
import { UserProfile } from '../models/user-profile';

/**
 * Implements the authentication functionality
 *
 * @export
 */
@Injectable({
    providedIn: 'root'
})
export class AccountService {
    TOKEN_KEY = 'accessToken';
    constructor(private http: HttpClient) {
    }

    /**
     * Performs the authentication action for establishing a new session
     *
     * @param email username registered in ProDoctivity
     * @param password password for the given username
     * @returns The userProfile info
     */
    authenticate(email: string, password: string): Promise<BasicOperationResult<UserProfile>> {
        const authenticateUserRequest = { email, password };
        return this.http.post<BasicOperationResult<UserProfile>>(`${environment.apecRRHHApiUrl}/accounts/authenticate`,
            authenticateUserRequest)
            .toPromise().then(resp => {
                if (resp.success) {
                    localStorage.setItem(this.TOKEN_KEY, JSON.stringify(resp.operationResult));
                }
                return resp;
            });
    }

    /**
     * Performs logout in the current established session
     */
    logout(): void {
        localStorage.clear();
    }

    public get currentUser(): UserProfile {
        return JSON.parse(localStorage.getItem(this.TOKEN_KEY)) as UserProfile;
    }

    public getUser(userId): Promise<UserProfile> {
        return this.http.get<UserProfile>(`${environment.apecRRHHApiUrl}/accounts/${userId}`).toPromise();
    }

    createUser(user) {
        return this.http.post<BasicOperationResult<UserProfile>>(`${environment.apecRRHHApiUrl}/accounts`,
            user).toPromise();
    }

    updateUser(user) {
        return this.http.post<BasicOperationResult<UserProfile>>(`${environment.apecRRHHApiUrl}/accounts/update`,
            user).toPromise();
    }
}
