using AppNamePlaceholder.Shared.Data;
using AppNamePlaceholder.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppNamePlaceholder.Shared.Services;

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
