using Intrepion.ToDo.Shared.Data;
using Intrepion.ToDo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intrepion.ToDo.Shared.Services;

public class ClassNamePlaceholderService : IClassNamePlaceholderService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ClassNamePlaceholderService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ClassNamePlaceholder>> GetAllAsync()
    {
        var objectNamePlaceholders = await _applicationDbContext.DatabaseNamePlaceholders.ToListAsync();

        return objectNamePlaceholders;
    }
}
