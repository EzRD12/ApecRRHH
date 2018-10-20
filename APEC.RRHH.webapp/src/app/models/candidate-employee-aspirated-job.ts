import { UserProfile } from './user-profile';
import { Job } from './job';

export class CandidateEmployeeAspiratedJob {
    id: string;
    candidateEmployeeId: string;
    jobId: string;
    job: Job;
    salaryToAspire: number;
    userIdWhoRecommendedIt: string;
    userWhoRecommendedIt: UserProfile;
}
