import { IdentificationType } from '../enums/identification-type.enum';
import { Competence } from './competence';
import { Language } from './language';
import { Preparation } from './preparation';
import { WorkExperience } from './work-experience';
import { Role } from '../enums/role.enum';

/**
 * Represents the information passed for authentication
 *
 * @export
 */
export class UserProfile {
    id: string;
    name: string;
    lastname: string;
    fullName: string;
    identification: string;
    identificationType: IdentificationType;
    birthDate: Date;
    competences: Competence[];
    languages: Language[];
    preparations: Preparation[];
    workExperiences: WorkExperience[];
    currentRole: Role;
    email: string;
}
