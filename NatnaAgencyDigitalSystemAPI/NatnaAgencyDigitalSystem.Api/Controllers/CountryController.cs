using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Service.Services;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class CountryController : ControllerBase
    {
       
            private readonly ICountryService _countryService;
            private readonly IMapper _mapper;

            public CountryController(ICountryService CountryService, IMapper mapper)
            {
                this._mapper = mapper;
                this._countryService = CountryService;
            }

            [HttpGet("")]
            public async Task<ActionResult<IEnumerable<Country>>> GetAllCountrys()
            {
                var Countrys = await _countryService.GetAllCountrys();
                var CountryResource = _mapper.Map<IEnumerable<Country>, IEnumerable<Country>>(Countrys).OrderByDescending(o=>o.CountryId);

                return Ok(CountryResource);
            }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryLists()
        {
            var Countrys = await _countryService.GetAllCountrys();
            var CountryResource = _mapper.Map<IEnumerable<DropDownPObject>, IEnumerable<DropDownPObject>>(Countrys.ToList().Select(s => new DropDownPObject
            {
                id=s.CountryId,
                name = s.Name
            }));

            return Ok(CountryResource);
        }

        [HttpGet("{id}")]
            [Authorize(Roles = "Test")]
            public async Task<ActionResult<Country>> GetCountryById(int id)
            {
                var Country = await _countryService.GetCountryById(id);
                var CountryResource = _mapper.Map<Country, Country>(Country);

                return Ok(CountryResource);
            }

            [HttpPost("")]
            [Authorize(Roles ="OnlyTest")]
            public async Task<ActionResult<Country>> CreateCountry([FromBody] CountryResource countryRes)
            {
            countryRes.CreatedBy = "1111";
            countryRes.ModifiedBy = "1111";
            countryRes.CreatedDate = DateTime.Now;
            countryRes.ModifiedDate = DateTime.Now;
            var validator = new CountryValidator();
                var validationResult = await validator.ValidateAsync(countryRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CountryToCreate = _mapper.Map<CountryResource, Country>(countryRes);

                var newCountry = await _countryService.CreateCountry(CountryToCreate);

                var Country = await _countryService.GetCountryById(newCountry.CountryId);

                var CountryResource = _mapper.Map<Country, Country>(Country);

                return Ok(CountryResource);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Country>> UpdateCountry(int id, [FromBody] CountryResource countryRes)
            {
                var validator = new CountryValidator();
                var validationResult = await validator.ValidateAsync(countryRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CountryToBeUpdated = await _countryService.GetCountryById(id);

                if (CountryToBeUpdated == null)
                    return NotFound();

                var Country = _mapper.Map<CountryResource, Country>(countryRes);

                await _countryService.UpdateCountry(CountryToBeUpdated, Country);

                var updatedCountry = await _countryService.GetCountryById(id);

                var updatedCountryResource = _mapper.Map<Country, Country>(updatedCountry);

                return Ok(updatedCountryResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCountry(int id)
            {
                var Country = await _countryService.GetCountryById(id);

                await _countryService.DeleteCountry(Country);

                return Ok("Deleted");
            }
        }

    }
