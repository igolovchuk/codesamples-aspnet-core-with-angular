﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.BLL.Services.Interfaces;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.UnitOfWork;

namespace CoreAngularDemo.BLL.Services.ImplementedServices
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UnitDTO> GetAsync(int id)
        {
            return _mapper.Map<UnitDTO>(await _unitOfWork.UnitRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<UnitDTO>> GetRangeAsync(uint offset, uint amount)
        {
            return _mapper.Map<IEnumerable<UnitDTO>>(await _unitOfWork.UnitRepository.GetRangeAsync(offset, amount));
        }

        public async Task<UnitDTO> CreateAsync(UnitDTO dto)
        {
            var model = _mapper.Map<Unit>(dto);

            await _unitOfWork.UnitRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UnitDTO>(model);
        }

        public async Task<UnitDTO> UpdateAsync(UnitDTO dto)
        {
            var model = _mapper.Map<Unit>(dto);

            _unitOfWork.UnitRepository.Update(model);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UnitDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.UnitRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<UnitDTO>> SearchAsync(string search)
        {
            var units = await _unitOfWork.UnitRepository.SearchAsync(
                new SearchTokenCollection(search)
            );

            return _mapper.Map<IEnumerable<UnitDTO>>(await units.ToListAsync());
        }
    }
}