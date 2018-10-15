import { FeatureStatus } from '../enums/feature-status';
import { UserProfile } from './user-profile';
import { Job } from './job';

export class Employee {
    id: string;
    userId: string;
    user: UserProfile;
    monthlySalary: number;
    jobId: string;
    job: Job;
    admissionDate: Date;
    status: FeatureStatus;
}
