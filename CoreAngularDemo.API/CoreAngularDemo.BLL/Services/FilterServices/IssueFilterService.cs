using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class IssueFilterService : BaseFilterService<Issue, IssueDTO>
    {
        public IssueFilterService(IQueryRepository<Issue> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
