import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'role'
})
export class RolePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return this.getTypeDescription(value);
  }

  getTypeDescription(typeId) {
    const types = [{ id: 1, description: 'Empleado candidato' },
    { id: 2, description: 'Empleado' },
    { id: 3, description: 'Supervisor' },
    { id: 4, description: 'Gerente' },
    { id: 5, description: 'Administrador' }
    ];

    const role = types.find((type) => type.id === typeId);

    return role ? role.description : 'Indefinido';
  }
}
