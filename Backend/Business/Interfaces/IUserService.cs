using System;
using Business.Dtos;

namespace Business.Interfaces;

public interface IUserService
{
    Task<UserResult> GetUsersAsync();
}