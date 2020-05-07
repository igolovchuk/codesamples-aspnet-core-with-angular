using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueDTO, Issue>()
                .ForMember(i => i.AssignedTo, opt => opt.MapFrom(x => x.AssignedTo.Id))
                .ForMember(i => i.CreatedById, opt => opt.Ignore())
                .ForMember(i => i.UpdatedById, opt => opt.Ignore())
                .ForMember(i => i.VehicleId, opt => opt.MapFrom(d => d.Vehicle.Id))
                .ForMember(i => i.MalfunctionId, opt => opt.MapFrom(d => d.Malfunction.Id))

                .ForMember(i => i.StateId, opt => opt.MapFrom(d => d.State.Id))
                .ForMember(i => i.State, opt => opt.Ignore())
                .ForMember(i => i.Mod, opt => opt.Ignore())
                .ForMember(i => i.Bill, opt => opt.Ignore())
                .ForMember(i => i.Create, opt => opt.Ignore())
                .ForMember(i => i.Vehicle, opt => opt.Ignore())
                .ForMember(i => i.IssueLog, opt => opt.Ignore())
                .ForMember(i => i.Malfunction, opt => opt.Ignore())
                .ForMember(i => i.AssignedTo, opt => opt.Ignore());

            CreateMap<Issue, IssueDTO>();
        }
    }
}
