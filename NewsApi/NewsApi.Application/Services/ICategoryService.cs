using NewsApi.Application.Dtos;

namespace NewsApi.Application.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> Create(string name);
        Task<CategoryDto> Update(int id, string name);
        Task Delete(string name);
        Task<CategoryDto> GetById(int id);
        Task<List<CategoryDto>> Get(string name);
    }
}
