using System;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{

}
