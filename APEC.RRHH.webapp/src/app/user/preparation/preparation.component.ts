import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Preparation } from '../../models/preparation';
import { ToastNotificationService, ToastType } from '../../services/toast-notification.service';

@Component({
  selector: 'app-preparation',
  templateUrl: './preparation.component.html',
  styleUrls: ['./preparation.component.css']
})
export class PreparationComponent implements OnInit {

  @Output() value: Preparation[];
  @Input() preparations: Preparation[];
  modalVisibility = false;
  createPreparationForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
              private toastNotificationService: ToastNotificationService) { }

  ngOnInit() {
    this.buildForm();
  }

  public buildForm() {
    this.createPreparationForm = this.formBuilder.group({
      description: [''],
      academicLevel: ['', Validators.required],
      dateFrom: ['', Validators.required],
      dateUp: ['', Validators.required],
      institution: ['', Validators.required],
    });
  }

  changeModalVisibility(visibility) {
    this.modalVisibility = visibility;
  }

  createPreparation() {
    const preparation = this.createPreparationForm.getRawValue();
    if (preparation.dateFrom < preparation.dateUp) {
      this.preparations.push(preparation);
      this.preparations = [...this.preparations];
    } else {
      this.displayToast('Error', 'Incorrecto datos de fechas elegidos', ToastType.Error);
    }
  }

  displayToast(title: string, message: string, toastType: ToastType): void {
    this.toastNotificationService.show({
      title: title,
      message: message
    }, toastType);
  }


}
