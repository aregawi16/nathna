using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Validators;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Setting;
using NatnaAgencyDigitalSystem.Api.Services;

namespace NatnaAgencyDigitalSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class OfficeController : ControllerBase
    {
       
            private readonly IOfficeService _OfficeService;
            private readonly IMapper _mapper;

            public OfficeController(IOfficeService OfficeService, IMapper mapper)
            {
                this._mapper = mapper;
                this._OfficeService = OfficeService;
            }

            [HttpGet("")]
            public async Task<ActionResult<IEnumerable<Office>>> GetAllOffices()
            {
                var Offices = await _OfficeService.GetAllOffices();
                var OfficeResource = _mapper.Map<IEnumerable<Office>, IEnumerable<Office>>(Offices).ToList().OrderByDescending(o=>o.OfficeId);

                return Ok(OfficeResource);
            }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOfficeLists()
        {
            var Offices = await _OfficeService.GetAllOffices();
            var OfficeResource = _mapper.Map<IEnumerable<DropDownPObject>, IEnumerable<DropDownPObject>>(Offices.ToList().Select(s => new DropDownPObject
            {
                id=s.OfficeId,
                name = s.Name
            }));

            return Ok(OfficeResource);
        }

        [HttpGet("{id}")]
            [Authorize(Roles = "Test")]
            public async Task<ActionResult<Office>> GetOfficeById(int id)
            {
                var Office = await _OfficeService.GetOfficeById(id);
                var OfficeResource = _mapper.Map<Office, Office>(Office);

                return Ok(OfficeResource);
            }

            [HttpPost("")]
            [Authorize(Roles ="OnlyTest")]
            public async Task<ActionResult<Office>> CreateOffice([FromBody] OfficeResource OfficeRes)
            {
            OfficeRes.CreatedBy = "1111";
            OfficeRes.ModifiedBy = "1111";
            OfficeRes.CreatedDate = DateTime.Now;
            OfficeRes.ModifiedDate = DateTime.Now;
            var validator = new OfficeValidator();
                var validationResult = await validator.ValidateAsync(OfficeRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var OfficeToCreate = _mapper.Map<OfficeResource, Office>(OfficeRes);

                var newOffice = await _OfficeService.CreateOffice(OfficeToCreate);

                var Office = await _OfficeService.GetOfficeById(newOffice.OfficeId);

                var OfficeResource = _mapper.Map<Office, Office>(Office);

                return Ok(OfficeResource);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Office>> UpdateOffice(int id, [FromBody] OfficeResource OfficeRes)
            {
                var validator = new OfficeValidator();
                var validationResult = await validator.ValidateAsync(OfficeRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var OfficeToBeUpdated = await _OfficeService.GetOfficeById(id);

                if (OfficeToBeUpdated == null)
                    return NotFound();

                var Office = _mapper.Map<OfficeResource, Office>(OfficeRes);

                await _OfficeService.UpdateOffice(OfficeToBeUpdated, Office);

                var updatedOffice = await _OfficeService.GetOfficeById(id);

                var updatedOfficeResource = _mapper.Map<Office, Office>(updatedOffice);

                return Ok(updatedOfficeResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteOffice(int id)
            {
                var Office = await _OfficeService.GetOfficeById(id);

                await _OfficeService.DeleteOffice(Office);

                return Ok("Deleted");
            }
        }

    }
