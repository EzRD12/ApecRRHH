import { Component, OnInit } from '@angular/core';
import { Language } from '../../models/language';
import { LanguageService } from '../../services/language.service';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {

  languageHeaders = ['Nombre', 'Estado'];
  languages: Language[] = [];
  modalVisibility = false;
  inputValue: string;
  isConfirmLoading = false;
  isDataLoading = true;
  constructor(private languageService: LanguageService) { }

  ngOnInit() {
    this.languageService.getAllLanguages().then( data => {
      this.isDataLoading = false;
      this.languages = data.operationResult;
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createLanguage() {
    this.isConfirmLoading = true;
    this.languageService.create(this.inputValue).then((result) => {
      this.inputValue = '';
      this.languages.push(result.operationResult);
      this.languages = [...this.languages];
      this.isConfirmLoading = false;
      this.changeModalVisibility(false);
    });
  }

  changeLanguageStatus(languageId) {
    this.languageService.changesLanguageStatus(languageId).then(operationResult => {
      if (operationResult.success) {
        const language = operationResult.operationResult;
        this.languages.forEach(data => data.status = data.id === language.id ? language.status : data.status);
      } else {
        console.log(operationResult.message);
      }
    });
  }

}
