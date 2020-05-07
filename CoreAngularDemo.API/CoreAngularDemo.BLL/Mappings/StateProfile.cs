using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.BLL.Mappings
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<StateDTO, State>()
                .ForMember(s => s.Issue, opt => opt.Ignore())
                .ForMember(s => s.IssueLogNewState, opt => opt.Ignore())
                .ForMember(s => s.IssueLogOldState, opt => opt.Ignore());
            CreateMap<State, StateDTO>();
        }
    }
}
