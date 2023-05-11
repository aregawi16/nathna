using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatnaAgencyDigitalSystem.Service
{
    public class ApplicantProfileService : IApplicantProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicantProfileService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        IUnitOfWork UnitOfWork { get; }

        public async Task<ApplicantProfile> CreateApplicantProfile(ApplicantProfile newApplicantProfile)
        {
            await _unitOfWork.ApplicantProfiles
                .AddAsync(newApplicantProfile);
            await _unitOfWork.CommitAsync();

            return newApplicantProfile;
        }

        public async Task DeleteApplicantProfile(ApplicantProfile ApplicantProfile)
        {
            _unitOfWork.ApplicantProfiles.Remove(ApplicantProfile);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ApplicantProfile>> GetAllApplicantProfiles()
        {
            return await _unitOfWork.ApplicantProfiles.GetAllAsync();
        }
          public async Task<IEnumerable<ApplicantProfile>> GetAllWithStatusAsync()
        {
            return await _unitOfWork.ApplicantProfiles.GetAllWithStatusAsync();
        }

        public async Task<ApplicantProfile> GetApplicantProfileById(int id)
        {
            return await _unitOfWork.ApplicantProfiles.GetByIdAsync(id);
        }
        public async Task<ApplicantProfile> GetWithWorkExperienceByIdAsync(int id)
        {
            return await _unitOfWork.ApplicantProfiles.GetWithWorkExperienceByIdAsync(id);
        }

        public async Task UpdateApplicantProfile(ApplicantProfile ApplicantProfileToBeUpdated, ApplicantProfile ApplicantProfile)
        {
            ApplicantProfileToBeUpdated.FirstName = ApplicantProfile.FirstName;
            ApplicantProfileToBeUpdated.FirstNameAm = ApplicantProfile.FirstNameAm;
            ApplicantProfileToBeUpdated.MiddleName = ApplicantProfile.MiddleName;
            ApplicantProfileToBeUpdated.MiddleNameAm = ApplicantProfile.MiddleNameAm;
            ApplicantProfileToBeUpdated.LastName = ApplicantProfile.LastName;
            ApplicantProfileToBeUpdated.LastNameAm = ApplicantProfile.LastNameAm;
            ApplicantProfileToBeUpdated.Email = ApplicantProfile.Email;
            ApplicantProfileToBeUpdated.City = ApplicantProfile.City;
            ApplicantProfileToBeUpdated.Wereda = ApplicantProfile.Wereda;
            ApplicantProfileToBeUpdated.Kebelle = ApplicantProfile.Kebelle;
            ApplicantProfileToBeUpdated.PassportNo = ApplicantProfile.PassportNo;
            ApplicantProfileToBeUpdated.PassportIssueDate = ApplicantProfile.PassportIssueDate;
            ApplicantProfileToBeUpdated.PassportExpiryDate = ApplicantProfile.PassportExpiryDate;
            ApplicantProfileToBeUpdated.PhoneNumber = ApplicantProfile.PhoneNumber;
            ApplicantProfileToBeUpdated.DoB = ApplicantProfile.DoB;
            ApplicantProfileToBeUpdated.Gender = ApplicantProfile.Gender;
            ApplicantProfileToBeUpdated.MaritalStatus = ApplicantProfile.MaritalStatus;
            ApplicantProfileToBeUpdated.ReferenceNo = ApplicantProfile.ReferenceNo;
            ApplicantProfileToBeUpdated.NoOfChildren = ApplicantProfile.NoOfChildren;
            ApplicantProfileToBeUpdated.Priority = ApplicantProfile.Priority;
            ApplicantProfileToBeUpdated.Religion = ApplicantProfile.Religion;
            ApplicantProfileToBeUpdated.CountryId = ApplicantProfile.CountryId;
            ApplicantProfileToBeUpdated.Nationality = ApplicantProfile.Nationality;
            ApplicantProfileToBeUpdated.AgentId = ApplicantProfile.AgentId;
            ApplicantProfileToBeUpdated.CountryId = ApplicantProfile.CountryId;
             //await _unitOfWork.ApplicantProfiles.UpdateAsync(ApplicantProfile);
 
           await _unitOfWork.CommitAsync();
        }
    }
}
