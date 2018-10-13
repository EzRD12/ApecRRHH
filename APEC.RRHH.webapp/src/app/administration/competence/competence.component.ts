import { Component, OnInit } from '@angular/core';
import { Competence } from '../../models/competence';
import { CompetenceService } from '../../services/competence.service';

@Component({
  selector: 'app-competence',
  templateUrl: './competence.component.html',
  styleUrls: ['./competence.component.css']
})
export class CompetenceComponent implements OnInit {

  competenceHeaders = ['Descripcion', 'Estado'];
  competences: Competence[] = [];
  modalVisibility = false;
  inputValue: string;
  isConfirmLoading = false;
  isDataLoading = true;
  constructor(private competenceService: CompetenceService) { }

  ngOnInit() {
    this.competenceService.getAllCompetences().then(data => {
      this.isDataLoading = false;
      this.competences = data.operationResult;
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createCompetence() {
    this.isConfirmLoading = true;
    this.competenceService.create(this.inputValue).then((result) => {
      this.competences.push(result.operationResult);
      this.isConfirmLoading = false;
    });
  }

}
