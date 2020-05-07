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
    /// Malfunction Group CRUD service
    /// </summary>
    /// <see cref="IMalfunctionGroupService"/>
    public class MalfunctionGroupService : IMalfunctionGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        public MalfunctionGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MalfunctionGroupDTO> GetAsync(int id)
        {
            return _mapper.Map<MalfunctionGroupDTO>(await _unitOfWork.MalfunctionGroupRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<MalfunctionGroupDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.MalfunctionGroupRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<MalfunctionGroupDTO>>(entities);
        }

        public async Task<IEnumerable<MalfunctionGroupDTO>> SearchAsync(string search)
        {
            var malfunctionGroupsDTO = await _unitOfWork.MalfunctionGroupRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<MalfunctionGroupDTO>>(await malfunctionGroupsDTO.ToListAsync());
        }

        public async Task<MalfunctionGroupDTO> CreateAsync(MalfunctionGroupDTO dto)
        {
            var model = _mapper.Map<MalfunctionGroup>(dto);

            await _unitOfWork.MalfunctionGroupRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<MalfunctionGroupDTO>(model);
        }

        public async Task<MalfunctionGroupDTO> UpdateAsync(MalfunctionGroupDTO dto)
        {
            var model = _mapper.Map<MalfunctionGroup>(dto);

            _unitOfWork.MalfunctionGroupRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<MalfunctionGroupDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.MalfunctionGroupRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}