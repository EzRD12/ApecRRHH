using System;
using System.Linq;
using Core.Contracts;
using Core.Models;
using Core.Ports.Repositories;
using FluentValidationsResult = FluentValidation.Results.ValidationResult;
using Core.Validations;

namespace Core.Managers
{
    public sealed class CandidateEmployeeManagers
    {
        private readonly ICandidateEmployeeRepository _candidateEmployeeRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ICandidateEmployeeAspiratedJobRepository _candidateEmployeeAspiratedJobRepository;


        public CandidateEmployeeManagers(ICandidateEmployeeRepository candidateEmployeeRepository, ICandidateEmployeeAspiratedJobRepository candidateEmployeeAspiratedJobRepository,
            IJobRepository jobRepository)
        {
            _candidateEmployeeRepository = candidateEmployeeRepository;
            _candidateEmployeeAspiratedJobRepository = candidateEmployeeAspiratedJobRepository;
            _jobRepository = jobRepository;
        }

        public IOperationResult<CandidateEmployee> Find(Guid id)
        {
            CandidateEmployee candidateEmployee = _candidateEmployeeRepository.Find(candidate => candidate.Id == id);
            return BasicOperationResult<CandidateEmployee>.Ok(candidateEmployee);
        }

        public IOperationResult<CandidateEmployeeAspiratedJob> AspirateToJob(CandidateEmployeeAspiratedJob candidateEmployeeAspiratedJob)
        {
            AspirateToJobValidator validator = new AspirateToJobValidator(_candidateEmployeeRepository, _jobRepository);
            FluentValidationsResult validationResult = validator.Validate(candidateEmployeeAspiratedJob);

            if (!validationResult.IsValid)
            {
                string errors = string.Join(",", validationResult.Errors.Select(errorsFound => errorsFound.ErrorMessage));
                return BasicOperationResult<CandidateEmployeeAspiratedJob>.Fail(errors);
            }

            return _candidateEmployeeAspiratedJobRepository.Create(candidateEmployeeAspiratedJob);
        }
    }
}
