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
    /// Part CRUD service
    /// </summary>
    /// <see cref="IPartService"/>
    public class PartService : IPartService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public PartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PartDTO> GetAsync(int id)
        {
            return _mapper.Map<PartDTO>(await _unitOfWork.PartRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PartDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.PartRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<PartDTO>>(entities);
        }

        public async Task<IEnumerable<PartDTO>> SearchAsync(string search)
        {
            var parts = await _unitOfWork.PartRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<PartDTO>>(await parts.ToListAsync());
        }

        public async Task<PartDTO> CreateAsync(PartDTO dto)
        {
            var model = _mapper.Map<Part>(dto);

            await _unitOfWork.PartRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PartDTO>(model);
        }

        public async Task<PartDTO> UpdateAsync(PartDTO dto)
        {
            var model = _mapper.Map<Part>(dto);

            _unitOfWork.PartRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<PartDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PartRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}