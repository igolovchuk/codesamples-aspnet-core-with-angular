using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class WorkTypeProfile :Profile
    {
        public WorkTypeProfile()
        {
            CreateMap<WorkTypeDTO, WorkType>()
                .ForMember(i => i.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(i => i.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(i => i.EstimatedCost, opt => opt.MapFrom(x => x.EstimatedCost))
                .ForMember(i => i.EstimatedTime, opt => opt.MapFrom(x => x.EstimatedTime))

                .ForMember(v => v.UpdatedById, opt => opt.Ignore())
                .ForMember(v => v.CreatedById, opt => opt.Ignore())
                .ForMember(v => v.Mod, opt => opt.Ignore())
                .ForMember(v => v.Create, opt => opt.Ignore())
                .ForMember(v => v.UpdatedDate, opt => opt.Ignore())
                .ForMember(v => v.CreatedDate, opt => opt.Ignore());
            CreateMap<WorkType, WorkTypeDTO>();
        }
    }
}
