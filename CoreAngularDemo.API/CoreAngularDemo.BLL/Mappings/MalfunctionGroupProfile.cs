using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class MalfunctionGroupProfile : Profile
    {
        public MalfunctionGroupProfile()
        {
            CreateMap<MalfunctionGroupDTO, MalfunctionGroup>()
                .ForMember(m => m.UpdatedById, opt => opt.Ignore())
                .ForMember(m => m.CreatedById, opt => opt.Ignore())
                .ForMember(m => m.Mod, opt => opt.Ignore())
                .ForMember(m => m.Create, opt => opt.Ignore())
                .ForMember(m => m.UpdatedDate, opt => opt.Ignore())
                .ForMember(m => m.CreatedDate, opt => opt.Ignore());
            CreateMap<MalfunctionGroup, MalfunctionGroupDTO>();
        }
    }
}
