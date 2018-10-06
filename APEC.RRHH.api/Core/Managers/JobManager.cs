using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidationsResult = FluentValidation.Results.ValidationResult;


namespace Core.Managers
{
    public sealed class JobManager
    {
        private readonly IJobRepository _jobRepository;
        private readonly IDepartamentRepository _departamentRepository;

        public JobManager(IJobRepository jobRepository, IDepartamentRepository departamentRepository)
        {
            _jobRepository = jobRepository;
            _departamentRepository = departamentRepository;
        }

        public IOperationResult<Job> Create(Job job)
        {
            CreateJobValidator validator = new CreateJobValidator(_jobRepository, _departamentRepository);
            FluentValidationsResult validationResult = validator.Validate(job);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(",", validationResult.Errors.Select(errorsFound => errorsFound.ErrorMessage));
                return BasicOperationResult<Job>.Fail(errors);
            }

            return _jobRepository.Create(job);
        }

        public IOperationResult<Job> Update(Job job)
        {
            UpdateJobValidator validator = new UpdateJobValidator(_jobRepository, _departamentRepository);
            FluentValidationsResult validationResult = validator.Validate(job);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(",", validationResult.Errors.Select(errorsFound => errorsFound.ErrorMessage));
                return BasicOperationResult<Job>.Fail(errors);
            }

            return _jobRepository.Update(job);
        }

        public IOperationResult<IEnumerable<Employee>> DisableJob(Guid jobId)
        {
            IEnumerable<Employee> employees = null;
            Job jobFound = _jobRepository.Find(job => job.Id == jobId, job => job.Employees);

            if (jobFound == null)
            {
                return BasicOperationResult<IEnumerable<Employee>>.Fail("JobNotFound");
            }

            jobFound.Status = FeatureStatus.Disabled;

            if (jobFound.Employees.Any(employee => employee.Status != FeatureStatus.Disabled))
            {
                employees = (_jobRepository.DeleteJob(jobId).Entity);

            }

            _jobRepository.Update(jobFound);

            return BasicOperationResult<IEnumerable<Employee>>.Ok(employees);
        }

        public IOperationResult<Job> Find(Guid jobId)
        {
            Job entity = _jobRepository.Find(job => job.Id == jobId, departament => departament.Employees, job => job.JobCompetences, job => job.JobLanguages);

            return entity == null
                ? BasicOperationResult<Job>.Fail("DepartamentDoesNotExistOnRepository")
                : BasicOperationResult<Job>.Ok(entity);
        }

        public IOperationResult<Job> EnableJob(Guid jobId)
        {
            Job jobFound = _jobRepository.Find(job => job.Id == jobId);

            if (jobFound == null)
            {
                return BasicOperationResult<Job>.Fail("JobNotFound");
            }

            jobFound.Status = FeatureStatus.Enabled;

            return _jobRepository.Update(jobFound);
        }
    }
}
