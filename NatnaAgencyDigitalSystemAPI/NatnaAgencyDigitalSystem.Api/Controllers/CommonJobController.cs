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

    public class CommonJobController : ControllerBase
    {
       
            private readonly ICommonJobService _CommonJobService;
            private readonly IMapper _mapper;

            public CommonJobController(ICommonJobService CommonJobService, IMapper mapper)
            {
                this._mapper = mapper;
                this._CommonJobService = CommonJobService;
            }

            [HttpGet("")]
            public async Task<ActionResult<IEnumerable<CommonJob>>> GetAllCommonJobs()
            {
                var CommonJobs = await _CommonJobService.GetAllCommonJobs();
                var CommonJobResource = _mapper.Map<IEnumerable<CommonJob>, IEnumerable<CommonJob>>(CommonJobs).OrderByDescending(o=>o.CommonJobId);

                return Ok(CommonJobResource);
            }
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CommonJob>>> GetCommonJobLists()
        {
            var CommonJobs = await _CommonJobService.GetAllCommonJobs();
            var CommonJobResource = _mapper.Map<IEnumerable<DropDownPObject>, IEnumerable<DropDownPObject>>(CommonJobs.ToList().Select(s => new DropDownPObject
            {
                id=s.CommonJobId,
                name = s.Name
            }));

            return Ok(CommonJobResource);
        }

        [HttpGet("{id}")]
            [Authorize(Roles = "Test")]
            public async Task<ActionResult<CommonJob>> GetCommonJobById(int id)
            {
                var CommonJob = await _CommonJobService.GetCommonJobById(id);
                var CommonJobResource = _mapper.Map<CommonJob, CommonJob>(CommonJob);

                return Ok(CommonJobResource);
            }

            [HttpPost("")]
            [Authorize(Roles ="OnlyTest")]
            public async Task<ActionResult<CommonJob>> CreateCommonJob([FromBody] CommonJobResource commonJobRes)
            {
            commonJobRes.CreatedBy = User.Identity.Name;
            commonJobRes.ModifiedBy = User.Identity.Name;
            commonJobRes.CreatedDate = DateTime.Now;
            commonJobRes.ModifiedDate = DateTime.Now;
                var validator = new CommonJobValidator();
                var validationResult = await validator.ValidateAsync(commonJobRes);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CommonJobToCreate = _mapper.Map<CommonJobResource, CommonJob>(commonJobRes);

                var newCommonJob = await _CommonJobService.CreateCommonJob(CommonJobToCreate);

                var CommonJob = await _CommonJobService.GetCommonJobById(newCommonJob.CommonJobId);

                var CommonJobResource = _mapper.Map<CommonJob, CommonJob>(CommonJob);

                return Ok(CommonJobResource);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<CommonJob>> UpdateCommonJob(int id, [FromBody] CommonJobResource commonJob)
            {
                var validator = new CommonJobValidator();
                var validationResult = await validator.ValidateAsync(commonJob);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

                var CommonJobToBeUpdated = await _CommonJobService.GetCommonJobById(id);

                if (CommonJobToBeUpdated == null)
                    return NotFound();

                var CommonJob = _mapper.Map<CommonJobResource, CommonJob>(commonJob);

                await _CommonJobService.UpdateCommonJob(CommonJobToBeUpdated, CommonJob);

                var updatedCommonJob = await _CommonJobService.GetCommonJobById(id);

                var updatedCommonJobResource = _mapper.Map<CommonJob, CommonJob>(updatedCommonJob);

                return Ok(updatedCommonJobResource);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCommonJob(int id)
            {
                var CommonJob = await _CommonJobService.GetCommonJobById(id);

                await _CommonJobService.DeleteCommonJob(CommonJob);

                return Ok("Deleted");
            }
        }

    }
