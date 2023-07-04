
using NatnaAgencyDigitalSystem.Api.Services;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Models;

namespace NatnaAgencyDigitalSystem.Service
{

    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<Country> CreateCountry(Country newCountry)
        {
            await _unitOfWork.Countrys
                .AddAsync(newCountry);
            await _unitOfWork.CommitAsync();

            return newCountry;
        }

        public async Task DeleteCountry(Country Country)
        {
            _unitOfWork.Countrys.Remove(Country);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Country>> GetAllCountrys()
        {
            return await _unitOfWork.Countrys.GetAllAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _unitOfWork.Countrys.GetByIdAsync(id);
        }

        public async Task UpdateCountry(Country CountryToBeUpdated, Country Country)
        {
            //  CountryToBeUpdated. = Country.Name;

            await _unitOfWork.CommitAsync();
        }
    }


}