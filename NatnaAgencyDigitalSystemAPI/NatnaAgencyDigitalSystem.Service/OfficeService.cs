using NatnaAgencyDigitalSystem.Api.Services;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Models;

namespace NatnaAgencyDigitalSystem.Service
{

    public class OfficeService : IOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OfficeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Office> CreateOffice(Office newOffice)
        {
            await _unitOfWork.Offices
                .AddAsync(newOffice);
            await _unitOfWork.CommitAsync();

            return newOffice;
        }

        public async Task DeleteOffice(Office Office)
        {
            _unitOfWork.Offices.Remove(Office);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Office>> GetAllOffices()
        {
            return await _unitOfWork.Offices.GetAllAsync();
        }

        public async Task<Office> GetOfficeById(int id)
        {
            return await _unitOfWork.Offices.GetByIdAsync(id);
        }

        public async Task UpdateOffice(Office OfficeToBeUpdated, Office Office)
        {
            //  OfficeToBeUpdated. = Office.Name;

            await _unitOfWork.CommitAsync();
        }
    }


}
