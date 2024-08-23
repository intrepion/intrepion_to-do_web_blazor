using AppNamePlaceholder.Shared.Entities;

namespace AppNamePlaceholder.Shared.Services;

public interface IClassNamePlaceholderService
{
    Task<List<ClassNamePlaceholder>> GetAllAsync();
}
