import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Competence } from '../../models/competence';
import { Departament } from '../../models/departament';
import { Job } from '../../models/job';
import { Language } from '../../models/language';
import { CompetenceService } from '../../services/competence.service';
import { DepartamentService } from '../../services/departament.service';
import { JobService } from '../../services/job.service';
import { LanguageService } from '../../services/language.service';
import { FeatureStatus } from '../../enums/feature-status';
import { NzModalService } from 'ng-zorro-antd';

@Component({
  selector: 'app-departament-jobs',
  templateUrl: './departament-jobs.component.html',
  styleUrls: ['./departament-jobs.component.css']
})
export class DepartamentJobsComponent implements OnInit {

  modalVisibility = false;
  isConfirmLoading = false;
  departament: Departament;
  departamentName: string;
  jobs: Job[] = [];
  inputValue: string;
  departamentId: string;
  jobsHeaders = ['Nombre', 'Riesgo', 'Cantidad de empleados actual', 'Cantidad requerida', 'Estado'];
  createJobForm: FormGroup;
  competences: Competence[] = [];
  competencesSelected: Competence[] = [];
  languages: Language[] = [];
  languagesSelected: Language[] = [];

  constructor(private departamentService: DepartamentService,
    private competenceService: CompetenceService,
    private languageService: LanguageService,
    private jobService: JobService,
    private activatedRoute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private modalService: NzModalService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(parameters => {
      this.departamentId = parameters.id;
    });
    this.buildForm();
    this.departamentService.getDepartamentJobs(this.departamentId).then((data) => {
      this.jobs = data;
    });
    this.departamentService.getDepartament(this.departamentId).then((data) => {
      this.departament = data;
      this.departamentName = data.name;
    });
    this.competenceService.getCompetencesAvailables().then((data) => {
      this.competences = data.operationResult;
    });
    this.languageService.getLanguagesAvailables().then((data) => {
      this.languages = data.operationResult;
    });
  }

  public buildForm() {
    this.createJobForm = this.formBuilder.group({
      name: [''],
      riskLevel: ['', Validators.required],
      minimumSalary: ['', Validators.required],
      maximumSalary: ['', Validators.required],
      quantityOfEmployeesNeeded: ['', Validators.required],
      currencyType: ['', Validators.required],
      minimumYearsExperienceLaboral: ['', Validators.required],
      competences: new FormControl(),
      languages: new FormControl()
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createJob() {
    this.isConfirmLoading = true;
    const job = this.createJobForm.getRawValue();
    job.competences = job.competences.map((competence) => {
      return { competenceId: competence };
    });

    job.languages = job.languages.map((language) => {
      return { languageId: language };
    });
    job.status = FeatureStatus.enabled;
    job.departamentId = this.departamentId;
    this.jobService.create(job).then((result) => {
      this.buildForm();
      this.jobs.push(result);
      this.jobs = [...this.jobs];
      this.isConfirmLoading = false;
      this.changeModalVisibility(false);
    });
  }

  showConfirm(departament: Departament) {
    this.modalService.confirm({
      nzTitle: 'Deshabilitar el puesto de trabajo ' + departament.name,
      nzContent: 'Si realiza esta accion todos empleados' +
        'de trabajo bajo este puesto seran deshabilitados de forma conjunta',
      nzOkText: 'Ok',
      nzCancelText: 'Cancel',
      nzOnOk: () => this.changesDepartamentStatus(departament.id)
    });
  }

  changesDepartamentStatus(jobId) {
    this.jobService.changeJobStatus(jobId).then((result) => {
      this.jobs.forEach(data => data.status = data.id === result.id ? result.status : data.status);
    });
  }

}
