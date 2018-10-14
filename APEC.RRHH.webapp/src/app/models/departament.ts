import { FeatureStatus } from '../enums/feature-status';
import { Job } from './job';

export class Departament {
    id: string;
    name: string;
    status: FeatureStatus;
    jobs: Job[] = [];
}
