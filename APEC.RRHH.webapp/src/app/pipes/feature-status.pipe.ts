import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'featureStatus'
})
export class FeatureStatusPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.getTypeDescription(value);
  }

  getTypeDescription(typeId) {
    const types = [{ id: 1, description: 'Habilitado' },
    { id: 2, description: 'Deshabilitado' },
    ];

    const featureStatus = types.find((type) => type.id === typeId);

    return featureStatus.description;
  }
}
