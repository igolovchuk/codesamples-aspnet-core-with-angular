using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class CoreAngularDemoionProfile : Profile
    {
        public CoreAngularDemoionProfile()
        {
            CreateMap<CoreAngularDemoionDTO, CoreAngularDemoion>()
            .ForMember(i => i.UpdatedById, opt => opt.Ignore())
            .ForMember(i => i.CreatedById, opt => opt.Ignore())
            .ForMember(i => i.Mod, opt => opt.Ignore())
            .ForMember(i => i.Create, opt => opt.Ignore())
            .ForMember(i => i.ActionType, opt => opt.Ignore())
            .ForMember(i => i.ActionTypeId, opt => opt.MapFrom(x => x.ActionType.Id))
            .ForMember(i => i.FromState, opt => opt.Ignore())
            .ForMember(i => i.FromStateId, opt => opt.MapFrom(x => x.FromState.Id))
            .ForMember(i => i.ToState, opt => opt.Ignore())
            .ForMember(i => i.ToStateId, opt => opt.MapFrom(x => x.ToState.Id))
            .ForMember(i => i.CreatedDate, opt => opt.Ignore())
            .ForMember(i => i.UpdatedDate, opt => opt.Ignore());

            CreateMap<CoreAngularDemoion, CoreAngularDemoionDTO>();
        }
    }
}
