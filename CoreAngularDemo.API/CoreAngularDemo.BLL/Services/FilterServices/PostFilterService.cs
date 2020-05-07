using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class PostFilterService : BaseFilterService<Post, PostDTO>
    {
        public PostFilterService(IQueryRepository<Post> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
