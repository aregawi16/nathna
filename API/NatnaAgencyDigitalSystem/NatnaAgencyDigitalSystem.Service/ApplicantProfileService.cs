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
          //  ApplicantProfileToBeUpdated. = ApplicantProfile.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
