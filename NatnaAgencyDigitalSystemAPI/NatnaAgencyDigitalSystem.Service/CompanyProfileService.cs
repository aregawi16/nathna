using NatnaAgencyDigitalSystem.Service.Services;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Core.Models;

namespace NatnaAgencyDigitalSystem.Service
{

    public class CompanyProfileService : ICompanyProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyProfileService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<CompanyProfile> CreateCompanyProfile(CompanyProfile newCompanyProfile)
        {
            await _unitOfWork.CompanyProfiles
                .AddAsync(newCompanyProfile);
            await _unitOfWork.CommitAsync();

            return newCompanyProfile;
        }

        public async Task DeleteCompanyProfile(CompanyProfile CompanyProfile)
        {
            _unitOfWork.CompanyProfiles.Remove(CompanyProfile);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CompanyProfile>> GetAllCompanyProfiles()
        {
            return await _unitOfWork.CompanyProfiles.GetAllAsync();
        }

        public async Task<CompanyProfile> GetCompanyProfileById(int id)
        {
            return await _unitOfWork.CompanyProfiles.GetByIdAsync(id);
        }

        public async Task UpdateCompanyProfile(CompanyProfile CompanyProfileToBeUpdated, CompanyProfile CompanyProfile)
        {
            //  CompanyProfileToBeUpdated. = CompanyProfile.Name;

            await _unitOfWork.CommitAsync();
        }
    }


}
