using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class CountryFilterService : BaseFilterService<Country, CountryDTO>
    {
        public CountryFilterService(IQueryRepository<Country> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
