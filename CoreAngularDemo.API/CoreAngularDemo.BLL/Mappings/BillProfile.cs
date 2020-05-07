using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillDTO, Bill>()
                .ForMember(b => b.UpdatedById, opt => opt.Ignore())
                .ForMember(b => b.CreatedById, opt => opt.Ignore())
                .ForMember(b => b.Mod, opt => opt.Ignore())
                .ForMember(b => b.Create, opt => opt.Ignore())
                .ForMember(b => b.DocumentId, opt => opt.MapFrom(x => x.Document.Id))
                .ForMember(b => b.Document, opt => opt.Ignore())
                .ForMember(b => b.IssueId, opt => opt.MapFrom(x => x.Issue.Id))
                .ForMember(b => b.Issue, opt => opt.Ignore());
            CreateMap<Bill, BillDTO>();
        }
    }
}
