
using Business.Dtos;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Extensions;

namespace Business.Services;



public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ClientResult> GetClientsAsync()
    {
        var result = await _clientRepository.GetAllAsync();
        return result.MapTo<ClientResult>();
    }

   
}
