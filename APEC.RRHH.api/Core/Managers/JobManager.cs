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

        public IOperationResult<IEnumerable<Job>> GetVacanciesAvailable()
        {
            IEnumerable<Job> jobs = _jobRepository.FindAll(job => job.QuantityOfEmployeesNeeded > job.Employees.Count, job => job.Employees,
                                                                                                                       job => job.Competences,
                                                                                                                       job => job.Languages);

            return BasicOperationResult<IEnumerable<Job>>.Ok(jobs);
        }

        public IOperationResult<Job> ChangeJobStatus(Guid jobId)
        {
            Job jobFound = _jobRepository.Find(job => job.Id == jobId, job => job.Employees);

            if (jobFound == null)
            {
                return BasicOperationResult<Job>.Fail("JobNotFound");
            }

            jobFound.Status = jobFound.Status == FeatureStatus.Enabled ? FeatureStatus.Disabled : FeatureStatus.Enabled;

            if (jobFound.Status == FeatureStatus.Disabled)
            {
                foreach (var employee in jobFound.Employees)
                {
                    employee.Status = FeatureStatus.Disabled;
                }
            }

            return _jobRepository.Update(jobFound);
        }

        public IOperationResult<Job> Find(Guid jobId)
        {
            Job entity = _jobRepository.Find(job => job.Id == jobId, departament => departament.Employees, job => job.Competences, job => job.Languages);

            return entity == null
                ? BasicOperationResult<Job>.Fail("JobDoesNotExistOnRepository")
                : BasicOperationResult<Job>.Ok(entity);
        }

        public IOperationResult<IEnumerable<Job>> GetByDepartament(Guid departamentId)
        {
            IEnumerable<Job> entity = _jobRepository.FindAll(job => job.DepartamentId == departamentId, departament => departament.Employees);

            return entity == null
                ? BasicOperationResult<IEnumerable<Job>>.Fail("JobDoesNotExistOnRepository")
                : BasicOperationResult<IEnumerable<Job>>.Ok(entity);
        }

        public IOperationResult<IEnumerable<Job>> GetAll()
        {
            IEnumerable<Job> jobs = _jobRepository.FindAll(job => job.Status == FeatureStatus.Enabled, departament => departament.Employees, job => job.Employees);

            return BasicOperationResult<IEnumerable<Job>>.Ok(jobs);
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
