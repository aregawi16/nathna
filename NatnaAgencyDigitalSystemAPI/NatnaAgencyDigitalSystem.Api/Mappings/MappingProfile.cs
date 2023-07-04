using AutoMapper;
using NatnaAgencyDigitalSystem.Api.Resources;
using NatnaAgencyDigitalSystem.Api.Models;
using NatnaAgencyDigitalSystem.Api.Models.Auth;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace MyMusic.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            //CreateMap<Music, MusicResource>();
            //CreateMap<Artist, ArtistResource>();

            //// Resource to Domain
            //CreateMap<MusicResource, Music>();
            //CreateMap<SaveMusicResource, Music>();
            //CreateMap<ArtistResource, Artist>();
            CreateMap<ApplicantProfileResource, ApplicantProfile>();
            CreateMap<WorkExperienceResource, WorkExperience>();
            CreateMap<ContactPersonResource, ContactPerson>();
            CreateMap<ExperiencedJobResource, ExperiencedJob>();
            CreateMap<AgentResource, Agent>();
            CreateMap<OfficeResource, Office>();
            CreateMap<CountryResource, Country>();
            CreateMap<CommonJobResource, CommonJob>();
            CreateMap<UserSignUpResource, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}

