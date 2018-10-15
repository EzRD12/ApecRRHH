using System;
using System.Collections.Generic;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;

namespace Core.Managers
{
    public sealed class EmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IOperationResult<Employee> Find(Guid employeeId)
        {
            Employee entity = _employeeRepository.Find(employee => employee.Id == employeeId);

            return entity == null
                ? BasicOperationResult<Employee>.Fail("EmployeeDoesNotExistOnRepository")
                : BasicOperationResult<Employee>.Ok(entity);
        }

        public IOperationResult<Employee> Create(Employee employee)
        {
            IOperationResult<Employee> operationResult = _employeeRepository.Create(employee);

            return operationResult;
        }

        public IOperationResult<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll();

            return BasicOperationResult<IEnumerable<Employee>>.Ok(employees);
        }

        public IOperationResult<Employee> Update(Employee employee)
        {
            Employee employeeFound = _employeeRepository.Find(emplo => emplo.Id == employee.Id);

            return employeeFound == null
                ? BasicOperationResult<Employee>.Fail("EmployeeDoesNotExistOnRepository")
                : _employeeRepository.Update(employee);
        }

        public IOperationResult<Employee> ChangeStatus(Guid employeeId)
        {
            Employee employeeFound = _employeeRepository.Find(emplo => emplo.Id == employeeId);

            employeeFound.Status = employeeFound.Status == FeatureStatus.Disabled ? FeatureStatus.Enabled : FeatureStatus.Disabled;

            return Update(employeeFound);
        }
    }
}
