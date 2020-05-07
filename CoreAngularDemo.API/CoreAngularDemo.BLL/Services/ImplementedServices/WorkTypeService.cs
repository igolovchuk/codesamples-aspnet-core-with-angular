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
    public class WorkTypeService :IWorkTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public WorkTypeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<WorkTypeDTO> GetAsync(int id)
        {
            return _mapper.Map<WorkTypeDTO>(await _unitOfWork.WorkTypeRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<WorkTypeDTO>> GetRangeAsync(uint offset, uint amount)
        {
            return _mapper.Map<IEnumerable<WorkTypeDTO>>(
                await _unitOfWork.WorkTypeRepository.GetRangeAsync(offset, amount)
            );
        }

        public async Task<IEnumerable<WorkTypeDTO>> SearchAsync(string search)
        {
            var workTypes = await _unitOfWork.WorkTypeRepository.SearchAsync(
                new SearchTokenCollection(search)
            );

            return _mapper.Map<IEnumerable<WorkTypeDTO>>(await workTypes.ToListAsync());
        }

        public async Task<WorkTypeDTO> CreateAsync(WorkTypeDTO dto)
        {
            var model = _mapper.Map<WorkType>(dto);
            await _unitOfWork.WorkTypeRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<WorkTypeDTO>(model);
        }

        public async Task<WorkTypeDTO> UpdateAsync(WorkTypeDTO dto)
        {
            var model = _mapper.Map<WorkType>(dto);
            _unitOfWork.WorkTypeRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<WorkTypeDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.WorkTypeRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }


    }
}
