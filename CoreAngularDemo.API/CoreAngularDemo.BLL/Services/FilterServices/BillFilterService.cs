using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class BillFilterService : BaseFilterService<Bill, BillDTO>
    {
        public BillFilterService(IQueryRepository<Bill> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
