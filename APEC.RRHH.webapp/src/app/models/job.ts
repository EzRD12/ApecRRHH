import { CurrencyType } from '../enums/currency-type.enum';
import { FeatureStatus } from '../enums/feature-status';
import { RiskLevel } from '../enums/risk-level.enum';
import { Employee } from './employee';
import { Language } from './language';
import { Competence } from './competence';
import { CandidateInterview } from './candidate-interview';

export class Job {
    id: string;
    name: string;
    minimumSalary: number;
    maxSalary: number;
    minimumYearsExperienceLaboral: number;
    quantityOfEmployeesNeeded: number;
    departamentId: string;
    currencyType: CurrencyType;
    status: FeatureStatus;
    riskLevel: RiskLevel;
    employees: Employee[];
    jobCompetences: Competence[];
    jobLanguages: Language[];
    interviews: CandidateInterview[];
}
