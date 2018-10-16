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
        console.log(email);
        return this.http.post<BasicOperationResult<UserProfile>>(`${environment.apecRRHHApiUrl}/accounts/authenticate`,
         authenticateUserRequest)
            .toPromise().then(resp => {
                if (resp.success) {
                    localStorage.setItem(this.TOKEN_KEY, JSON.stringify(resp));
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
}
