using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class MalfunctionSubgroupProfile : Profile
    {
        public MalfunctionSubgroupProfile()
        {
            CreateMap<MalfunctionSubgroupDTO, MalfunctionSubgroup>()
                .ForMember(m => m.UpdatedById, opt => opt.Ignore())
                .ForMember(m => m.CreatedById, opt => opt.Ignore())
                .ForMember(m => m.Mod, opt => opt.Ignore())
                .ForMember(m => m.Create, opt => opt.Ignore())
                .ForMember(m => m.UpdatedDate, opt => opt.Ignore())
                .ForMember(m => m.CreatedDate, opt => opt.Ignore())
                .ForMember(m => m.MalfunctionGroupId, opt => opt.MapFrom(x => x.MalfunctionGroup.Id))
                .ForMember(m => m.MalfunctionGroup, opt => opt.Ignore());
            CreateMap<MalfunctionSubgroup, MalfunctionSubgroupDTO>();
        }        
    }
}
