using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class ActionTypeFilterService : BaseFilterService<ActionType, ActionTypeDTO>
    {
        public ActionTypeFilterService(IQueryRepository<ActionType> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}