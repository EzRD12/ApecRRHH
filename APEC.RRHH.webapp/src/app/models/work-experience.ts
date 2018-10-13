import { CurrencyType } from '../enums/currency-type.enum';

export class WorkExperience {
    id: string;
    userId: string;
    positionHeld: string;
    yearExperiences: Date;
    salary: number;
    dateFrom: Date;
    dateUp: Date;
    currencyType: CurrencyType;
}
