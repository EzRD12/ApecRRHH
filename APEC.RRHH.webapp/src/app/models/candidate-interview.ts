import { CandidateEmployee } from './candidate-employee';
import { CandidateEmployeeAspiratedJob } from './candidate-employee-aspirated-job';
import { Employee } from './employee';
import { Job } from './job';

export class CandidateInterview {
    id: string;
    candidateEmployeeId: string;
    candidateEmployeeAspiratedJobId: string;
    candidateEmployee: CandidateEmployee;
    candidateEmployeeAspiratedJob: CandidateEmployeeAspiratedJob;
    jobId: string;
    job: Job;
    interviewDate: Date;
    employeeIdWhoInterviewed: string;
    employee: Employee;
    employeeNotes: string;
    hired: boolean;
}
