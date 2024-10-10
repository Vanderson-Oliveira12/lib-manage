﻿using LibManage.Models;
using LibManage.DTOs.User;

namespace LibManage.Repositories.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> FindByIdAsync(Guid id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> EmailExists(string email);

    }
}
