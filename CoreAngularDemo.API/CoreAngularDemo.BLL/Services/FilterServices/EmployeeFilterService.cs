using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class EmployeeFilterService : BaseFilterService<Employee, EmployeeDTO>
    {
        public EmployeeFilterService(IQueryRepository<Employee> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
