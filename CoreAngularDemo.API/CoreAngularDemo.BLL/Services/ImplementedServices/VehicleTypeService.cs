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
    /// Service for Vehicle Type
    /// </summary>
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public VehicleTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<VehicleTypeDTO> GetAsync(int id)
        {
            return _mapper.Map<VehicleTypeDTO>(await _unitOfWork.VehicleTypeRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<VehicleTypeDTO>> GetRangeAsync(uint offset, uint amount)
        {
            return _mapper.Map<IEnumerable<VehicleTypeDTO>>(
                await _unitOfWork.VehicleTypeRepository.GetRangeAsync(offset, amount)
            );
        }

        public async Task<IEnumerable<VehicleTypeDTO>> SearchAsync(string search)
        {
            var vehicleTypes = await _unitOfWork.VehicleTypeRepository.SearchAsync(
                new SearchTokenCollection(search)
            );

            return _mapper.Map<IEnumerable<VehicleTypeDTO>>(await vehicleTypes.ToListAsync());
        }

        public async Task<VehicleTypeDTO> CreateAsync(VehicleTypeDTO dto)
        {
            var model = _mapper.Map<VehicleType>(dto);
            await _unitOfWork.VehicleTypeRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VehicleTypeDTO>(model);
        }

        public async Task<VehicleTypeDTO> UpdateAsync(VehicleTypeDTO dto)
        {
            var model = _mapper.Map<VehicleType>(dto);
            _unitOfWork.VehicleTypeRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<VehicleTypeDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.VehicleTypeRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}