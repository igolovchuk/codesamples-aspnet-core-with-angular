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
    public class ManufacturerService : IManufacturerService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ManufacturerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ManufacturerDTO> GetAsync(int id)
        {
            return _mapper.Map<ManufacturerDTO>(await _unitOfWork.ManufacturerRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ManufacturerDTO>> GetRangeAsync(uint offset, uint amount)
        {
            return _mapper.Map<IEnumerable<ManufacturerDTO>>(await _unitOfWork.ManufacturerRepository.GetRangeAsync(offset, amount));
        }

        public async Task<ManufacturerDTO> CreateAsync(ManufacturerDTO dto)
        {
            var model = _mapper.Map<Manufacturer>(dto);

            await _unitOfWork.ManufacturerRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ManufacturerDTO>(model);
        }

        public async Task<ManufacturerDTO> UpdateAsync(ManufacturerDTO dto)
        {
            var model = _mapper.Map<Manufacturer>(dto);

            _unitOfWork.ManufacturerRepository.Update(model);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ManufacturerDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ManufacturerRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ManufacturerDTO>> SearchAsync(string search)
        {
            var manufacturers = await _unitOfWork.ManufacturerRepository.SearchAsync(
                new SearchTokenCollection(search)
            );

            return _mapper.Map<IEnumerable<ManufacturerDTO>>(await manufacturers.ToListAsync());
        }
    }
}