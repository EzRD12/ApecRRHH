import { Component, OnInit } from '@angular/core';
import { Departament } from '../models/departament';
import { DepartamentService } from '../services/departament.service';
import { NzModalService } from 'ng-zorro-antd';

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

  constructor(private departamentService: DepartamentService,
    private modalService: NzModalService) { }

  ngOnInit() {
    this.departamentService.getAllDepartaments().then(data => {
      this.departaments = data;
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  showConfirm(departament: Departament) {
    this.modalService.confirm({
      nzTitle: 'Deshabilitar el departamento de ' + departament.name,
      nzContent: 'Si realiza esta accion todos los puestos y empleados' +
        'de trabajo bajo este departamento seran deshabilitados de forma conjunta',
      nzOkText: 'Ok',
      nzCancelText: 'Cancel',
      nzOnOk: () => this.changesDepartamentStatus(departament.id)
    });
  }

  changesDepartamentStatus(departamentId) {
    this.departamentService.changeDepartamentStatus(departamentId).then((result) => {
      this.departaments.forEach(data => data.status = data.id === result.id ? result.status : data.status);
    });
  }

  createDepartament() {
    this.isConfirmLoading = true;
    this.departamentService.create(this.inputValue).then((result) => {
      this.departaments.push(result);
      this.departaments = [...this.departaments];
      this.isConfirmLoading = false;
      this.changeModalVisibility(false);
    });
  }
}
