import { FeatureStatus } from '../enums/feature-status';
import { CandidateEmployeeAspiratedJob } from './candidate-employee-aspirated-job';
import { CandidateInterview } from './candidate-interview';
import { UserProfile } from './user-profile';

export class CandidateEmployee {
    id: string;
    userId: string;
    user: UserProfile;
    status: FeatureStatus;
    interviews: CandidateInterview[];
    candidateEmployeeAspiratedJobs: CandidateEmployeeAspiratedJob[];
}
