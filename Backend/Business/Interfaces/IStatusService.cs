
using Business.Dtos;

namespace Business.Interfaces;

public interface IStatusService
{
    Task<StatusResult> GetStatusesAsync();
}