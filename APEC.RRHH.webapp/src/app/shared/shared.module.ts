import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FeatureStatusPipe } from '../pipes/feature-status.pipe';
import { RiskLevelPipe } from '../pipes/risk-level.pipe';
import { RolePipe } from '../pipes/role.pipe';
import { CurrencyTypePipe } from '../pipes/currency-type.pipe';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [FeatureStatusPipe, RiskLevelPipe, RolePipe, CurrencyTypePipe],
  exports: [FeatureStatusPipe, RiskLevelPipe, RolePipe, CurrencyTypePipe]
})
export class SharedModule {
}
