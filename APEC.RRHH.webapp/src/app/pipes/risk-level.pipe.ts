import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'riskLevel'
})
export class RiskLevelPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.getTypeDescription(value);
  }

  getTypeDescription(typeId) {
    const types = [{ id: 1, description: 'Bajo' },
    { id: 2, description: 'Medio' },
    { id: 3, description: 'Alto' }
    ];

    const riskLevel = types.find((type) => type.id === typeId);

    return riskLevel ? riskLevel.description : 'Indefinido';
  }
}
