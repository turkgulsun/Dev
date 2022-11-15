using Dev.Services.Catalog.DTOs;
using Dev.Shared.DTOs;

namespace Dev.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryCreateDto>> CreateAsync(CategoryCreateDto category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
