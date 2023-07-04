
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Data;
using AutoMapper;
using NatnaAgencyDigitalSystem.Api.Services;

namespace NatnaAgencyDigitalSystem.Api.Helper
{
    public class UserHelper
    {
        private NatnaAgencyDbContext _db;
        private readonly UserManager<User> _userManager;
        private readonly IApplicantProfileService _ApplicantProfileService;
        private readonly IMapper _mapper;

        public UserHelper(IApplicantProfileService ApplicantProfileService, IMapper mapper, NatnaAgencyDbContext db, UserManager<User> userManager)
        {
            this._mapper = mapper;

            this._ApplicantProfileService = ApplicantProfileService;
            this._db = db;
            this._userManager = userManager;

        }
        //void  getApplicationProfile()
        //{
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    if (user != null)
        //    {
        //        var appPlacmentIds = _db.ApplicantPlacements.Where(q => q.OfficeId == user.OfficeId).Select(s => s.ApplicantProfileId);
        //        var ApplicantProfiles = await _ApplicantProfileService.GetAllWithStatusAsync();

        //        var office = await _db.Offices.FindAsync(user.OfficeId);
        //        if (office != null)
        //        {
        //            if (office.IsHeadOffice)
        //            {
        //                if (!User.IsInRole("admin"))
        //                {
        //                    ApplicantProfiles = ApplicantProfiles.Where(q => q.CreatedBy == User.Identity.Name);
        //                }
        //            }
        //            else
        //            {
        //                ApplicantProfiles = ApplicantProfiles.Where(q => appPlacmentIds.Contains(q.ApplicantProfileId));

        //            }
        //        }

        //        var ApplicantProfileResource = _mapper.Map<IEnumerable<ApplicantProfile>, IEnumerable<ApplicantProfile>>(ApplicantProfiles);


        //        return Ok(ApplicantProfileResource);
        //    }
        //}

    }



}
