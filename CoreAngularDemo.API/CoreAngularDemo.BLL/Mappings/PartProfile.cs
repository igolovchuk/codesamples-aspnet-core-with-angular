using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<PartDTO, Part>()
                .ForMember(e => e.UnitId, opt => opt.MapFrom(e => e.Unit.Id))
                .ForMember(e => e.ManufacturerId, opt => opt.MapFrom(e => e.Manufacturer.Id))
                .ForMember(e => e.Unit, opt => opt.Ignore())
                .ForMember(e => e.Manufacturer, opt => opt.Ignore());

            CreateMap<Part, PartDTO>();
        }
    }
}
