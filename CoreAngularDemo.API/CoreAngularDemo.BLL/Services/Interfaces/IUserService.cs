﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services.Interfaces
{
    /// <summary>
    /// User model CRUD
    /// </summary>
    public interface IUserService
    {
        Task<UserDTO> UpdatePasswordAsync(UserDTO user, string newPassword);
        Task<IEnumerable<UserDTO>> GetAssignees(uint offset, uint amount);
        Task<UserDTO> GetAsync(string id);
        Task<IEnumerable<UserDTO>> GetRangeAsync(uint offset, uint amount);
        Task<UserDTO> CreateAsync(UserDTO value);
        Task<UserDTO> UpdateAsync(UserDTO value);
        Task DeleteAsync(string id);
        Task<IEnumerable<RoleDTO>> GetRoles();
        void UpdateCurrentUserId(string newValue);
        string GetCurrentUserId();
    }
}
