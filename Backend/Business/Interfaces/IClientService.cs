using System;
using Business.Dtos;

namespace Business.Interfaces;

public interface IClientService
{
    Task<ClientResult> GetClientsAsync();
}