﻿using System.Collections.Generic;
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
    /// Malfunction CRUD service
    /// </summary>
    /// <see cref="IMalfunctionService"/>
    public class MalfunctionService : IMalfunctionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        public MalfunctionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MalfunctionDTO> GetAsync(int id)
        {
            return _mapper.Map<MalfunctionDTO>(await _unitOfWork.MalfunctionRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<MalfunctionDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.MalfunctionRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<MalfunctionDTO>>(entities);
        }


        public async Task<IEnumerable<MalfunctionDTO>> GetBySubgroupNameAsync(string subgroupName)
        {
            var entities = await _unitOfWork.MalfunctionRepository.GetAllAsync(
                m => m.MalfunctionSubgroup.Name==subgroupName);

            return _mapper.Map<IEnumerable<MalfunctionDTO>>(entities);
        }

        public async Task<IEnumerable<MalfunctionDTO>> SearchAsync(string search)
        {
            var malfunctions = await _unitOfWork.MalfunctionRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<MalfunctionDTO>>(await malfunctions.ToListAsync());
        }

        public async Task<MalfunctionDTO> CreateAsync(MalfunctionDTO dto)
        {
            var model = _mapper.Map<Malfunction>(dto);

            await _unitOfWork.MalfunctionRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<MalfunctionDTO>(model);
        }

        public async Task<MalfunctionDTO> UpdateAsync(MalfunctionDTO dto)
        {
            var model = _mapper.Map<Malfunction>(dto);

            _unitOfWork.MalfunctionRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<MalfunctionDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.MalfunctionRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}