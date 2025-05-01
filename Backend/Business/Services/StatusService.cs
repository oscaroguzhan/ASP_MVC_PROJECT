
using Business.Dtos;
using Data.Interfaces;
using Domain.Models;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository)
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<StatusResult> GetAllAsync()
    {
        var result = await _statusRepository.GetAllAsync();
        return result.Success
        ? new StatusResult
        {
            Success = true,
            StatusCode = 200,
            Result = result.Result?.Select(entity => new Status
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
                // Map other properties as needed
            })
        }
        : new StatusResult
        {
            Success = false,
            StatusCode = result.StatusCode,
            Error = result.Error
        };;
    }
}
