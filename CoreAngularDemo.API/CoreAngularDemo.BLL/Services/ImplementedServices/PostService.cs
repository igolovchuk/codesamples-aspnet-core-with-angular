using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.BLL.Services.Interfaces;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.UnitOfWork;

namespace CoreAngularDemo.BLL.Services.ImplementedServices
{
    /// <summary>
    /// Post CRUD service
    /// </summary>
    /// <see cref="IPostService"/>
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        public PostService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostDTO> GetAsync(int id)
        {
            return _mapper.Map<PostDTO>(await _unitOfWork.PostRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PostDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.PostRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<PostDTO>>(entities);
        }

        public async Task<IEnumerable<PostDTO>> SearchAsync(string search)
        {
            var posts = await _unitOfWork.PostRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<PostDTO>>(await posts.ToListAsync());
        }

        public async Task<PostDTO> CreateAsync(PostDTO dto)
        {
            var model = _mapper.Map<Post>(dto);
            await _unitOfWork.PostRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PostDTO>(model);
        }

        public async Task<PostDTO> UpdateAsync(PostDTO dto)
        {
            var model = _mapper.Map<Post>(dto);
            _unitOfWork.PostRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PostDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PostRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}