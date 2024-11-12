using AutoMapper;
using Laptopy.DTOs;
using Laptopy.Models;
namespace Laptopy.Profiles
{
    public class ApplicationUserProfiles: Profile
    {
        public ApplicationUserProfiles()
        {
            CreateMap<ApplicationUserDTO, ApplicationUser>()
            .ForMember(dest => dest.UserName, option => option.MapFrom(src => $"{src.FristName}_{src.LastName}"));
        }
    }
}
