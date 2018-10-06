using System;
using Core.Models;
using Core.Ports.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Validations
{
    internal sealed class AspirateToJobValidator : AbstractValidator<CandidateEmployeeAspiratedJob>
    {
        private readonly ICandidateEmployeeRepository _candidateEmployeeRepository;
        private readonly IJobRepository _jobRepository;

        public AspirateToJobValidator(ICandidateEmployeeRepository candidateEmployeeRepository, IJobRepository jobRepository)
        {
            _candidateEmployeeRepository = candidateEmployeeRepository;
            _jobRepository = jobRepository;
            RuleFor(request => request.CandidateEmployeeId).Must(CandidateEmployeeExist).WithMessage("CandidateEmployeeDoesNotExistOnRepository");
            RuleFor(request => request.JobId).Must(JobExist).WithMessage("JobDoesNotExistOnRepository");
            RuleFor(request => request.JobId).Must(ExistsAvailableVacancies).WithMessage("JobDoesNotHasAvailableVacancies");
        }

        private bool CandidateEmployeeExist(Guid candidateEmployeeId) 
            => _candidateEmployeeRepository.Exists(candidate => candidate.Id == candidateEmployeeId);

        private bool JobExist(Guid jobId)
            => _jobRepository.Exists(job => job.Id == jobId);

        private bool ExistsAvailableVacancies(Guid jobId)
            => _jobRepository.Exists(job => job.Id == jobId && job.QuantityOfEmployeesNeeded > job.Employees.Count, job => job.Employees);

        /// <inheritdoc />
        public override ValidationResult Validate(ValidationContext<CandidateEmployeeAspiratedJob> context)
            => context.InstanceToValidate == null ? BuildValidationResult() : base.Validate(context);


        private ValidationResult BuildValidationResult()
            => new ValidationResult(new[]
                { new ValidationFailure("CandidateEmployeeAspiratedJob", "InvalidCreateCandidateEmployeeAspiratedJobInstance") });
    }
}