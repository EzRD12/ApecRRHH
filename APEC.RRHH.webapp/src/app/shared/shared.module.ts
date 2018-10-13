import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FeatureStatusPipe } from '../pipes/feature-status.pipe';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [FeatureStatusPipe],
  exports: [FeatureStatusPipe]
})
export class SharedModule {
}
