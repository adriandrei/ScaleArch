using AutoMapper;
using ScaleArch.ApiTemplate.Models;
using ScaleArch.ApiTemplate.ViewModels;

namespace ScaleArch.ApiTemplate.Profiles;

public class Generic : Profile
{
	public Generic()
	{
        CreateMap<SampleEntity, GetSampleViewModel>()
            .ForMember(t => t.Id, p => p.MapFrom(src => src.Id))
            .ForMember(t => t.Name, p => p.MapFrom(src => src.Name))
            .ForMember(t => t.CreatedAt, p => p.MapFrom(src => src.CreatedAt))
            .ForMember(t => t.UpdatedAt, p => p.MapFrom(src => src.UpdatedAt));
    }
}
