using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// State Group CRUD service
    /// </summary>
    /// <see cref="IStateService"/>
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        public StateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns state by name
        /// </summary>
        /// <param name="name">State's name</param>
        /// <returns>State</returns>
        /// <see cref="IStateService"/>
        public async Task<StateDTO> GetStateByNameAsync(string name)
        {
            return _mapper.Map<StateDTO>((await _unitOfWork.StateRepository.GetAllAsync(s => s.Name == name))
                .SingleOrDefault());
        }

        public async Task<StateDTO> GetAsync(int id)
        {
            return _mapper.Map<StateDTO>(await _unitOfWork.StateRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<StateDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.StateRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<StateDTO>>(entities);
        }

        public async Task<IEnumerable<StateDTO>> SearchAsync(string search)
        {
            var states = await _unitOfWork.StateRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<StateDTO>>(await states.ToListAsync());
        }

        public async Task<StateDTO> CreateAsync(StateDTO dto)
        {
            var model = _mapper.Map<State>(dto);
            await _unitOfWork.StateRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<StateDTO>(model);
        }

        public async Task<StateDTO> UpdateAsync(StateDTO stateDTO)
        {
            var model = _mapper.Map<State>(await GetAsync((int)stateDTO.Id));
            if (model.IsFixed)
            {
                throw new ConstraintException("Current state can not be edited");
            }
            if (stateDTO.IsFixed)
            {
                throw new ArgumentException("Incorrect model");
            };

            model.TransName = stateDTO.TransName;

            _unitOfWork.StateRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<StateDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetAsync(id);
            if (model.IsFixed)
            {
                throw new ConstraintException("Current state can not be deleted");
            }

            await _unitOfWork.StateRepository.RemoveAsync(model.Id);
            await _unitOfWork.SaveAsync();
        }
    }
}