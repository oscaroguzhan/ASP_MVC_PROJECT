
using Business.Dtos;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Extensions;
using Domain.Models;


namespace Business.Services;


public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<StatusResult> GetStatusesAsync()
    {
        var result = await _statusRepository.GetAllAsync();
        return result.MapTo<StatusResult>();
    }

}
