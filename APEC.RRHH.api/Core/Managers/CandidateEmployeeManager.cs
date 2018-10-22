using System;
using System.Collections.Generic;
using System.Linq;
using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using FluentValidationsResult = FluentValidation.Results.ValidationResult;
using Core.Validations;

namespace Core.Managers
{
    public sealed class CandidateEmployeeManager
    {
        private readonly ICandidateEmployeeRepository _candidateEmployeeRepository;
        private readonly ICandidateInterviewRepository _candidateInterviewRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICandidateEmployeeAspiratedJobRepository _candidateEmployeeAspiratedJobRepository;


        public CandidateEmployeeManager(ICandidateEmployeeRepository candidateEmployeeRepository, ICandidateEmployeeAspiratedJobRepository candidateEmployeeAspiratedJobRepository,
            IJobRepository jobRepository, ICandidateInterviewRepository candidateInterviewRepository, IUserRepository userRepository)
        {
            _candidateEmployeeRepository = candidateEmployeeRepository;
            _candidateEmployeeAspiratedJobRepository = candidateEmployeeAspiratedJobRepository;
            _jobRepository = jobRepository;
            _candidateInterviewRepository = candidateInterviewRepository;
            _userRepository = userRepository;
        }

        public IOperationResult<CandidateEmployee> Create(CandidateEmployee candidateEmployee)
        {
            bool candidateEmployeeExist = _candidateEmployeeRepository.Exists(candidate => candidate.UserId == candidateEmployee.UserId);

            return candidateEmployeeExist
                ? BasicOperationResult<CandidateEmployee>.Fail("ThisUserHasAlreadyACandidateEmployeeProfile")
                : _candidateEmployeeRepository.Create(candidateEmployee);
        }

        public IOperationResult<CandidateInterview> CreateCandidateInterview(CandidateInterview candidateInterview)
        {
            bool interviewAlreadyExist = _candidateInterviewRepository.Exists(candidate => candidate.CandidateEmployeeId == candidateInterview.CandidateEmployeeId
                                                                                            && candidate.JobId == candidateInterview.JobId);

            if (interviewAlreadyExist)
            {
                return BasicOperationResult<CandidateInterview>.Fail("AInterviewForThisCandidateAlreadyExists");
            }

            IOperationResult<CandidateInterview> operationResult = _candidateInterviewRepository.Create(candidateInterview);

            if (operationResult.Success)
            {
                CandidateEmployeeAspiratedJob aspiratedJob = _candidateEmployeeAspiratedJobRepository.Find(aspiration => aspiration.Id == operationResult.OperationResult.CandidateEmployeeAspiratedJobId);
                aspiratedJob.Status = FeatureStatus.Disabled;
                _candidateEmployeeAspiratedJobRepository.Update(aspiratedJob);
            }

            return operationResult;
        }

        public IOperationResult<IEnumerable<CandidateInterview>> GetCandidateOnAcceptationProcess()
        {
            IEnumerable<CandidateInterview> candidateEmployees = _candidateInterviewRepository.FindAll(employee => employee.InterviewDate.Date > DateTime.Today.Date,
                interview => interview.CandidateEmployee.User,
                interview => interview.Employee,
                interview => interview.Employee.User,
                interview => interview.Job
                );

            return BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(candidateEmployees);
        }

        public IOperationResult<IEnumerable<CandidateInterview>> GetCandidateInterviewHistory()
        {
            IEnumerable<CandidateInterview> candidateEmployees = _candidateInterviewRepository.FindAll(employee => employee.InterviewDate.Date < DateTime.Today.Date);

            return BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(candidateEmployees);
        }

        public IOperationResult<IEnumerable<CandidateInterview>> GetAllInterviews()
            => BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(_candidateInterviewRepository.Get());

        public IOperationResult<IEnumerable<CandidateInterview>> GetPendingInterviews()
            => BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(_candidateInterviewRepository.FindAll(interview => !interview.Hired
                                                                                                                           && interview.InterviewDate.Date > DateTime.Now.Date));

        public IOperationResult<CandidateInterview> FindInterviewProfile(Guid candidateInterviewId)
        {
            CandidateInterview candidateInterview = _candidateInterviewRepository.Find(candidate => candidate.Id == candidateInterviewId);
            return BasicOperationResult<CandidateInterview>.Ok(candidateInterview);
        }

        public IOperationResult<CandidateInterview> UpdateCandidateInterview(CandidateInterview candidateInterview)
        {
            bool interviewAlreadyExist = _candidateInterviewRepository.Exists(candidate => candidate.Id == candidateInterview.Id);
            if (!interviewAlreadyExist)
            {
                return BasicOperationResult<CandidateInterview>.Fail("InterviewDoesNotExistsOnRepository");
            }
            return _candidateInterviewRepository.Update(candidateInterview);
        }

        public IOperationResult<CandidateInterview> ContractCandidate(Guid candidateInterviewId)
        {
            CandidateInterview candidateInterview = _candidateInterviewRepository.Find(candidate => candidate.Id == candidateInterviewId);
            if (candidateInterview == null)
            {
                return BasicOperationResult<CandidateInterview>.Fail("InterviewDoesNotExistsOnRepository");
            }

            candidateInterview.Hired = true;
            candidateInterview.Employee.Status = FeatureStatus.Disabled;
            candidateInterview.Employee.User.CurrentRole = Role.Employee;

            return _candidateInterviewRepository.Update(candidateInterview);
        }

        public IOperationResult<CandidateEmployee> Find(Guid id)
        {
            CandidateEmployee candidateEmployee = _candidateEmployeeRepository.Find(candidate => candidate.Id == id);
            return BasicOperationResult<CandidateEmployee>.Ok(candidateEmployee);
        }

        public IOperationResult<CandidateEmployee> FindByUserId(Guid userId)
        {
            CandidateEmployee candidateEmployee = _candidateEmployeeRepository.Find(candidate => candidate.UserId == userId);
            return BasicOperationResult<CandidateEmployee>.Ok(candidateEmployee);
        }

        public IOperationResult<IEnumerable<CandidateEmployee>> GetAllActives()
        {
            IEnumerable<CandidateEmployee> candidateEmployees = _candidateEmployeeRepository.FindAll(candidate => candidate.Status == FeatureStatus.Enabled,
                candidate => candidate.User,
                employee => employee.User.Preparations,
                employee => employee.User.Languages);
            return BasicOperationResult<IEnumerable<CandidateEmployee>>.Ok(candidateEmployees);
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

            candidateEmployeeAspiratedJob.Status = FeatureStatus.Enabled;
            return _candidateEmployeeAspiratedJobRepository.Create(candidateEmployeeAspiratedJob);
        }

        public IOperationResult<IEnumerable<CandidateEmployeeAspiratedJob>> GetAllAspirationJobs()
        {
            IEnumerable<CandidateEmployeeAspiratedJob> aspirations = _candidateEmployeeAspiratedJobRepository
                .FindAll(aspirates => aspirates.Status == FeatureStatus.Enabled,
                    job => job.CandidateEmployee,
                    job => job.CandidateEmployee.User,
                    job => job.Job);
            foreach (var candidateEmployeeAspiratedJob in aspirations)
            {
                if (candidateEmployeeAspiratedJob.UserId != null)
                {
                    candidateEmployeeAspiratedJob.UserWhoRecomendedIt = _userRepository.Find(user =>
                        user.Id == candidateEmployeeAspiratedJob.UserId);
                }

            }
            return BasicOperationResult<IEnumerable<CandidateEmployeeAspiratedJob>>.Ok(aspirations);
        }
    }
}
