using AutoMapper;
using ScaleArch.ProfileService.Contracts;
using ScaleArch.ProfileServiceApi.Models;

namespace ScaleArch.ProfileServiceApi.Profiles;

public class General : Profile
{
    public General()
    {
        CreateMap<Permission, PermissionViewModel>()
            .ForMember(t => t.Id, p => p.MapFrom(src => src.Id))
            .ForMember(t => t.Name, p => p.MapFrom(src => src.Name));

        CreateMap<User, UserViewModel>()
            .ForMember(t => t.Id, p => p.MapFrom(src => src.Id))
            .ForMember(t => t.Name, p => p.MapFrom(src => src.Name))
            .ForMember(t => t.CreatedAt, p => p.MapFrom(src => src.CreatedAt))
            .ForMember(t => t.UpdatedAt, p => p.MapFrom(src => src.UpdatedAt))
            .ForMember(t => t.Permissions, p => p.MapFrom(src => src.Permissions));
    }
}
