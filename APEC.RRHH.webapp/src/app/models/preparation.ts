import { AcademicLevel } from '../enums/academic-level.enum';

export class Preparation {
    id: string;
    userId: string;
    description: string;
    academicLevel: AcademicLevel;
    dateFrom: Date;
    dateUp: Date;
    institution: string;
}
