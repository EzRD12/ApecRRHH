import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyType'
})
export class CurrencyTypePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.getTypeDescription(value);
  }

  getTypeDescription(typeId) {
    const types = [{ id: 1, description: 'Dolares americanos' },
    { id: 2, description: 'Pesos dominicanos' },
    ];

    const currencyType = types.find((type) => type.id === typeId);

    return currencyType ? currencyType.description : 'Indefinido';
  }
}
