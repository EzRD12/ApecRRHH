using Core.Contracts;
using Core.Enums;
using Core.Models;
using Core.Ports.Repositories;
using System;
using System.Collections.Generic;

namespace Core.Managers
{
    public sealed class ConfigurationManager
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ICompetenceRepository _competenceRepository;
        private readonly IPreparationRepository _preparationRepository;

        public ConfigurationManager(ILanguageRepository languageRepository, ICompetenceRepository competenceRepository, IPreparationRepository preparationRepository)
        {
            _languageRepository = languageRepository;
            _competenceRepository = competenceRepository;
            _preparationRepository = preparationRepository;
        }

        public IOperationResult<Language> CreateLanguage(Language language)
        {
            bool languageAlreadyExists = _languageRepository.Exists(lan => lan.Name == language.Name);

            if (languageAlreadyExists)
            {
                return BasicOperationResult<Language>.Fail("LanguageNameAlreadyExistsOnRepository");
            }

            return _languageRepository.Create(language);
        }

        public IOperationResult<Language> UpdateLanguage(Language language)
        {
            bool languageAlreadyExists = _languageRepository.Exists(lan => lan.Id == language.Id);

            if (!languageAlreadyExists)
            {
                return BasicOperationResult<Language>.Fail("LanguageDoesNotExistOnRepository");
            }

            return _languageRepository.Update(language);
        }

        public IOperationResult<Language> DeleteLanguage(Guid languageId)
        {
            Language languageFound = _languageRepository.Find(lan => lan.Id == languageId);

            if (languageFound == null)
            {
                return BasicOperationResult<Language>.Fail("LanguageDoesNotExistOnRepository");
            }

            return _languageRepository.Remove(languageFound);
        }

        public IOperationResult<IEnumerable<Language>> GetAllLanguages()
        {
            IEnumerable<Language> languages = _languageRepository.Get();

            return BasicOperationResult<IEnumerable<Language>>.Ok(languages);
        }

        public IOperationResult<Language> ChangeLanguageState(Guid languageId, FeatureStatus status)
        {
            Language languageFound = _languageRepository.Find(language => language.Id == languageId);

            if (languageFound == null)
            {
                return BasicOperationResult<Language>.Fail("LanguageDoesNotExistOnRepository");
            }

            languageFound.Status = status;

            return _languageRepository.Update(languageFound);
        }

        public IOperationResult<Competence> CreateCompetence(Competence competence)
        {
            bool competenceAlreadyExist = _competenceRepository.Exists(lan => lan.Description == competence.Description);

            if (competenceAlreadyExist)
            {
                return BasicOperationResult<Competence>.Fail("CompetenceDescriptionAlreadyExistsOnRepository");
            }

            return _competenceRepository.Create(competence);
        }

        public IOperationResult<Competence> UpdateCompetence(Competence competence)
        {
            bool competenceAlreadyExist = _competenceRepository.Exists(lan => lan.Id == competence.Id);

            if (!competenceAlreadyExist)
            {
                return BasicOperationResult<Competence>.Fail("CompetenceDoesNotExistOnRepository");
            }

            return _competenceRepository.Update(competence);
        }

        public IOperationResult<Competence> DeleteCompetence(Guid competenceId)
        {
            Competence competenceFound = _competenceRepository.Find(lan => lan.Id == competenceId);

            if (competenceFound == null)
            {
                return BasicOperationResult<Competence>.Fail("CompetenceDoesNotExistOnRepository");
            }

            return _competenceRepository.Remove(competenceFound);
        }

        public IOperationResult<IEnumerable<Competence>> GetAllCompetences()
        {
            IEnumerable<Competence> languages = _competenceRepository.Get();

            return BasicOperationResult<IEnumerable<Competence>>.Ok(languages);
        }

        public IOperationResult<Competence> ChangeCompetenceState(Guid competenceId, FeatureStatus status)
        {
            Competence competenceFound = _competenceRepository.Find(competence => competence.Id == competenceId);

            if (competenceFound == null)
            {
                return BasicOperationResult<Competence>.Fail("CompetenceDoesNotExistOnRepository");
            }

            competenceFound.Status = status;

            return _competenceRepository.Update(competenceFound);
        }

        public IOperationResult<Preparation> CreatePreparatin(Preparation preparation)
        {
            bool preparationAlreadyExists = _preparationRepository.Exists(lan => lan.Description == preparation.Description 
                                                                                 && lan.UserId == preparation.UserId 
                                                                                 && lan.Institution == preparation.Institution);

            return preparationAlreadyExists 
                ? BasicOperationResult<Preparation>.Fail("PreparationAlreadyExistsOnRepository") 
                : _preparationRepository.Create(preparation);
        }

        public IOperationResult<Preparation> UpdatePreparation(Preparation preparation)
        {
            bool preparationAlreadyExist = _preparationRepository.Exists(lan => lan.Id == preparation.Id);

            if (!preparationAlreadyExist)
            {
                return BasicOperationResult<Preparation>.Fail("PreparationDoesNotExistOnRepository");
            }

            return _preparationRepository.Update(preparation);
        }

        public IOperationResult<Preparation> DeletePreparation(Guid preparationId)
        {
            Preparation preparationFound = _preparationRepository.Find(lan => lan.Id == preparationId);

            if (preparationFound == null)
            {
                return BasicOperationResult<Preparation>.Fail("PreparationDoesNotExistOnRepository");
            }

            return _preparationRepository.Remove(preparationFound);
        }

        public IOperationResult<IEnumerable<Preparation>> GetAllPreparation()
        {
            IEnumerable<Preparation> preparations = _preparationRepository.Get();

            return BasicOperationResult<IEnumerable<Preparation>>.Ok(preparations);
        }
    }
}
