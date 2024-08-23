using Intrepion.ToDo.Shared.Entities;

namespace Intrepion.ToDo.Shared.Services;

public interface IClassNamePlaceholderService
{
    Task<List<ClassNamePlaceholder>> GetAllAsync();
}
