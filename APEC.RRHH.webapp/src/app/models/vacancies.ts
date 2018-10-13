import { CurrencyType } from '../enums/currency-type.enum';
import { FeatureStatus } from '../enums/feature-status';
import { RiskLevel } from '../enums/risk-level.enum';

export class Vacancies {
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
}
