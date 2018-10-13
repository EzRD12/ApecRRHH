import { FeatureStatus } from '../enums/feature-status';
import { UserProfile } from './user-profile';

export class Employee {
    id: string;
    userId: string;
    user: UserProfile;
    monthlySalary: number;
    jobId: string;
    admissionDate: Date;
    status: FeatureStatus;
}
