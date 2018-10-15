import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FeatureStatusPipe } from '../pipes/feature-status.pipe';
import { RiskLevelPipe } from '../pipes/risk-level.pipe';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [FeatureStatusPipe, RiskLevelPipe],
  exports: [FeatureStatusPipe, RiskLevelPipe]
})
export class SharedModule {
}
