import { Component, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WorkExperience } from '../../models/work-experience';

@Component({
  selector: 'app-work-experiences',
  templateUrl: './work-experiences.component.html',
  styleUrls: ['./work-experiences.component.css']
})
export class WorkExperiencesComponent implements OnInit {

  @Output() value: WorkExperience[];
  createWorkExperienceForm: FormGroup;
  modalVisibility = false;
  @Input() workExperiences: WorkExperience[] = [];

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }

  public buildForm() {
    this.createWorkExperienceForm = this.formBuilder.group({
      position: ['', Validators.required],
      salary: ['', Validators.required],
      dateFrom: ['', Validators.required],
      dateUp: ['', Validators.required],
      institution: ['', Validators.required],
      currencyType: ['', Validators.required],
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createWorkExperience() {
    const workExperience = this.createWorkExperienceForm.getRawValue();
    this.workExperiences.push(workExperience);
    this.workExperiences = [...this.workExperiences];
  }
}
