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
      this.languages.push(result.operationResult);
      this.isConfirmLoading = false;
    });
  }

}
