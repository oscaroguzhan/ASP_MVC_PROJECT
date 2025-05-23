
using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;



public class UserService(IUserRepository userRepository, UserManager<UserEntity> userManager) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly UserManager<UserEntity> _userManager = userManager;

    
    public async Task<UserResult> GetUsersAsync()
    {
       // how to get all users
         var users = await _userManager.Users.ToListAsync();

        var result = await _userRepository.GetAllAsync();
        return result.MapTo<UserResult>();
    }

}

