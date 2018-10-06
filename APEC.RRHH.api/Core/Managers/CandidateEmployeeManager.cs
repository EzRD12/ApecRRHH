using System;
using System.Collections.Generic;
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
        private readonly ICandidateInterviewRepository _candidateInterviewRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ICandidateEmployeeAspiratedJobRepository _candidateEmployeeAspiratedJobRepository;


        public CandidateEmployeeManagers(ICandidateEmployeeRepository candidateEmployeeRepository, ICandidateEmployeeAspiratedJobRepository candidateEmployeeAspiratedJobRepository,
            IJobRepository jobRepository, ICandidateInterviewRepository candidateInterviewRepository)
        {
            _candidateEmployeeRepository = candidateEmployeeRepository;
            _candidateEmployeeAspiratedJobRepository = candidateEmployeeAspiratedJobRepository;
            _jobRepository = jobRepository;
            _candidateInterviewRepository = candidateInterviewRepository;
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

            return _candidateInterviewRepository.Create(candidateInterview);
        }

        public IOperationResult<IEnumerable<CandidateInterview>> GetAllInterviews() 
            => BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(_candidateInterviewRepository.Get());

        public IOperationResult<IEnumerable<CandidateInterview>> GetPendingInterviews()
            => BasicOperationResult<IEnumerable<CandidateInterview>>.Ok(_candidateInterviewRepository.FindAll(interview => !interview.Hired 
                                                                                                                           && interview.InterviewDate.Date > DateTime.Now.Date));

        public IOperationResult<CandidateInterview> Find(Guid candidateEmployeeId, Guid jobId)
        {
            CandidateInterview candidateInterview = _candidateInterviewRepository.Find(candidate => candidate.CandidateEmployeeId == candidateEmployeeId
                                                                                                   && candidate.JobId == jobId);
            return BasicOperationResult<CandidateInterview>.Ok(candidateInterview);
        }

        public IOperationResult<CandidateInterview> UpdateCandidateInterview(CandidateInterview candidateInterview)
        {
            bool interviewAlreadyExist = _candidateInterviewRepository.Exists(candidate => candidate.CandidateEmployeeId == candidateInterview.CandidateEmployeeId
                                                                                                    && candidate.JobId == candidateInterview.JobId);
            if (!interviewAlreadyExist)
            {
                return BasicOperationResult<CandidateInterview>.Fail("InterviewDoesNotExistsOnRepository");
            }
            return _candidateInterviewRepository.Update(candidateInterview);
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
