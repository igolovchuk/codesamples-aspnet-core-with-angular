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
    /// Supplier CRUD service
    /// </summary>
    /// <see cref="ISupplierService"/>
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="unitOfWork">Unit of work pattern</param>
        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> GetAsync(int id)
        {
            return _mapper.Map<SupplierDTO>(await _unitOfWork.SupplierRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<SupplierDTO>> GetRangeAsync(uint offset, uint amount)
        {
            var entities = await _unitOfWork.SupplierRepository.GetRangeAsync(offset, amount);
            return _mapper.Map<IEnumerable<SupplierDTO>>(entities);
        }

        public async Task<IEnumerable<SupplierDTO>> SearchAsync(string search)
        {
            var suppliers = await _unitOfWork.SupplierRepository.SearchAsync(
                    new SearchTokenCollection(search)
                );

            return _mapper.Map<IEnumerable<SupplierDTO>>(await suppliers.ToListAsync());
        }

        public async Task<SupplierDTO> CreateAsync(SupplierDTO dto)
        {
            var model = _mapper.Map<Supplier>(dto);
            await _unitOfWork.SupplierRepository.AddAsync(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<SupplierDTO>(model);
        }

        public async Task<SupplierDTO> UpdateAsync(SupplierDTO dto)
        {
            var model = _mapper.Map<Supplier>(dto);
            _unitOfWork.SupplierRepository.Update(model);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<SupplierDTO>(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.SupplierRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}