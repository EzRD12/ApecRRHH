import { Component, OnInit } from '@angular/core';
import { Departament } from '../models/departament';
import { DepartamentService } from '../services/departament.service';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styleUrls: ['./departament.component.css']
})
export class DepartamentComponent implements OnInit {
  modalVisibility = false;
  isConfirmLoading = false;
  departaments: Departament[] = [];
  inputValue: string;
  departamentHeaders = ['Nombre', 'Estado'];

  constructor(private departamentService: DepartamentService) { }

  ngOnInit() {
    this.departamentService.getAllDepartaments().then(data => {
      this.departaments = data;
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createDepartament() {
    this.isConfirmLoading = true;
    this.departamentService.create(this.inputValue).then((result) => {
      this.departaments.push(result.operationResult);
      this.isConfirmLoading = false;
    });
  }
}
