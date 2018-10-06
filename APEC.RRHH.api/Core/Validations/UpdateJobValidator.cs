using Core.Models;
using Core.Ports.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Core.Validations
{
    internal sealed class UpdateJobValidator : AbstractValidator<Job>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IDepartamentRepository _departamentRepository;

        public UpdateJobValidator(IJobRepository jobRepository, IDepartamentRepository departamentRepository)
        {
            _jobRepository = jobRepository;
            _departamentRepository = departamentRepository;
            RuleFor(request => request.QuantityOfEmployeesNeeded).GreaterThan(0).WithMessage("InvalidQuantityOfEmployeesNeeded");
            RuleFor(request => request.Id).Must(JobExists).WithMessage("JobDoesNotExistsOnRepository");
            RuleFor(request => request.DepartamentId).Must(DepartamentExist).WithMessage("DepartamentDoesNotExistOnRepository");
            RuleFor(request => request.JobCompetences.Count).GreaterThan(0).WithMessage("InvalidJobCompetencesCount");
            RuleFor(request => request.JobLanguages.Count).GreaterThan(0).WithMessage("InvalidJobLanguagesCount");
        }

        private bool JobExists(Guid id)
            => !_jobRepository.Exists(job => job.Id == id);

        private bool DepartamentExist(Guid id)
            => _departamentRepository.Exists(departament => departament.Id == id);

        /// <inheritdoc />
        public override ValidationResult Validate(ValidationContext<Job> context)
            => context.InstanceToValidate == null ? BuildValidationResult() : base.Validate(context);


        private ValidationResult BuildValidationResult()
            => new ValidationResult(new[]
                { new ValidationFailure("Job", "InvalidUpdateJobInstance") });
    }
}