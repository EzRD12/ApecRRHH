using Core.Models;
using Core.Ports.Repositories;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Core.Validations
{
    public sealed class CreateJobValidator : AbstractValidator<Job>
    {
        private readonly IJobRepository _jobRepository;
        private readonly IDepartamentRepository _departamentRepository;

        public CreateJobValidator(IJobRepository jobRepository, IDepartamentRepository departamentRepository)
        {
            _jobRepository = jobRepository;
            _departamentRepository = departamentRepository;
            RuleFor(request => request.QuantityOfEmployeesNeeded).GreaterThan(0).WithMessage("InvalidQuantityOfEmployeesNeeded");
            RuleFor(request => request.Name).Must(ExistJobName).WithMessage("JobNameIsAlreadyInUsed");
            RuleFor(request => request.DepartamentId).Must(DepartamentExist).WithMessage("DepartamentDoesNotExistOnRepository");
            RuleFor(request => request.Competences.Count).GreaterThan(0).WithMessage("InvalidJobCompetencesCount");
            RuleFor(request => request.Languages.Count).GreaterThan(0).WithMessage("InvalidJobLanguagesCount");

        }

        private bool DepartamentExist(Guid id) 
            => _departamentRepository.Exists(departament => departament.Id == id);

        private bool ExistJobName(string name)
            => !_jobRepository.Exists(job => job.Name == name);

        /// <inheritdoc />
        public override ValidationResult Validate(ValidationContext<Job> context)
            => context.InstanceToValidate == null ? BuildValidationResult() : base.Validate(context);


        private ValidationResult BuildValidationResult()
            => new ValidationResult(new[]
                { new ValidationFailure("Job", "InvalidCreateJobInstance") });
    }
}