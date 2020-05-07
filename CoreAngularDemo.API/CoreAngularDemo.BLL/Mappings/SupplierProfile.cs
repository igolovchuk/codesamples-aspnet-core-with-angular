using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<SupplierDTO, Supplier>()
                .ForMember(s => s.CountryId, opt => opt.MapFrom(x => x.Country.Id))
                .ForMember(s => s.CurrencyId, opt => opt.MapFrom(x => x.Currency.Id))
                .ForMember(s => s.Country, opt => opt.Ignore())
                .ForMember(s => s.Currency, opt => opt.Ignore())
                .ForMember(s => s.UpdatedById, opt => opt.Ignore())
                .ForMember(s => s.CreatedById, opt => opt.Ignore())
                .ForMember(s => s.IssueLog, opt => opt.Ignore());
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
