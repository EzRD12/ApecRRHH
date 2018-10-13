﻿using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Managers
{
    public sealed class DepartamentManager
    {
        private readonly IDepartamentRepository _departamentRepository;
        private readonly IJobRepository _jobRepository;

        public DepartamentManager(IDepartamentRepository departamentRepository, IJobRepository jobRepository)
        {
            _departamentRepository = departamentRepository;
            _jobRepository = jobRepository;
        }

        public IOperationResult<Departament> Create(Departament departament)
        {
            bool departamentAlreadyExists = _departamentRepository.Exists(depart => depart.Name == departament.Name);

            if (departamentAlreadyExists)
            {
                return BasicOperationResult<Departament>.Fail("DepartamentNameIsAlreadyInUsed");
            }

            return _departamentRepository.Create(departament);
        }

        public IOperationResult<DisableDepartementResponse> DisableDepartament(Guid departamentId)
        {
            IEnumerable<Job> jobs = null;
            List<Employee> employees = new List<Employee>();
            Departament departament = _departamentRepository.Find(depart => depart.Id == departamentId, depart => depart.Jobs);

            if (departament == null)
            {
                return BasicOperationResult<DisableDepartementResponse>.Fail("DepartamentNotFound");
            }

            departament.Status = FeatureStatus.Disabled;

            if (departament.Jobs.Any(job => job.Status != FeatureStatus.Disabled))
            {
                jobs = _departamentRepository.DeleteDepartament(departamentId).OperationResult;

                foreach (var departamentJob in departament.Jobs)
                {
                    employees.AddRange(_jobRepository.DeleteJob(departamentJob.Id).OperationResult);
                }
            }

            _departamentRepository.Update(departament);

            DisableDepartementResponse response = new DisableDepartementResponse(jobs, employees);

            return BasicOperationResult<DisableDepartementResponse>.Ok(response);
        }

        public IOperationResult<Departament> Find(Guid departamentId)
        {
            Departament departamentFound = _departamentRepository.Find(departament => departament.Id == departamentId, departament => departament.Jobs);

            return departamentFound == null 
                ? BasicOperationResult<Departament>.Fail("DepartamentDoesNotExistOnRepository") 
                : BasicOperationResult<Departament>.Ok(departamentFound);
        }

        public IOperationResult<Departament> EnableDepartament(Guid departamentId)
        {
            Departament departament = _departamentRepository.Find(depart => depart.Id == departamentId);

            if (departament == null)
            {
                return BasicOperationResult<Departament>.Fail("DepartamentNotFound");
            }

            departament.Status = FeatureStatus.Enabled;

            return _departamentRepository.Update(departament);
        }
    }
}
