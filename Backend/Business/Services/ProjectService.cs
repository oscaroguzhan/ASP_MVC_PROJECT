using System;
using Business.Dtos;
using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Domain.Extensions;
using Domain.Models;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IStatusService statusService)
{
    public readonly IProjectRepository _projectRepository = projectRepository;
    public readonly IStatusService _statusService = statusService;



    public async Task<ProjectResult> CreateProjectAsync(AddProjectFormData formData) {
        var projectEntity = formData.MapTo<ProjectEntity>();
        
        var response = await _projectRepository.AddAsync(projectEntity);
        return response.Success ? new ProjectResult {
            Success = true,
            StatusCode = 201
        } : new ProjectResult {
            Success = false,
            StatusCode = 400,
            Error = response.Error ?? "Failed to create project"
        };
    }
    public async Task<ProjectResult<IEnumerable<Project>>> GetProjectsAsync()
    {
        var response = await _projectRepository.GetAllAsync(orderByDescending: true, sortBy: p => p.CreatedAt, where: null,
            include => include.User,
            include => include.Status,
            include => include.Client

        );
        return new ProjectResult<IEnumerable<Project>>
        {
            Result = response.Result,
            Success = true,
            StatusCode = 200
        };
    }
    public async Task<ProjectResult<IEnumerable<Project>>> GetProjectAsync(string id)
    {
        var response = await _projectRepository.GetAsync(where: p => p.Id == id,
            include => include.User,
            include => include.Status,
            include => include.Client

        );
        if (response.Result == null)
        {
            return new ProjectResult<IEnumerable<Project>>
            {
                Success = false,
                StatusCode = 404,
                Error = "Project not found"
            };
        }
        return new ProjectResult<IEnumerable<Project>>
        {
            Result = [response.Result],
            Success = true,
            StatusCode = 200
        };
    }
}
