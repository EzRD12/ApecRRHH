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

@Component({
  selector: 'app-departament-jobs',
  templateUrl: './departament-jobs.component.html',
  styleUrls: ['./departament-jobs.component.css']
})
export class DepartamentJobsComponent implements OnInit {

  modalVisibility = false;
  isConfirmLoading = false;
  departament: Departament;
  jobs: Job[] = [];
  inputValue: string;
  departamentId: string;
  jobsHeaders = ['Nombre', 'Riesgo', 'Cantidad actual', 'Cantidad requerida', 'Estado'];
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
              private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(parameters => {
      this.departamentId = parameters.id;
    });
    this.buildForm();
    this.departamentService.getDepartamentJobs(this.departamentId).then( (data) => {
      this.jobs = data;
    });
    this.competenceService.getAllCompetences().then( (data) => {
      this.competences = data.operationResult;
    });
    this.languageService.getAllLanguages().then( (data) => {
      this.languages = data.operationResult;
    });
  }

  public buildForm() {
    this.createJobForm = this.formBuilder.group({
      name: [''],
      riskLevel: ['', Validators.required],
      minimumSalary: ['', Validators.required],
      maximumSalary: ['', Validators.required],
      quantityOdEmployeesNeeded: ['', Validators.required],
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
    console.log(job);
    this.jobService.create(job).then((result) => {
      this.departament.jobs.push(result.operationResult);
      this.isConfirmLoading = false;
    });
  }

}
