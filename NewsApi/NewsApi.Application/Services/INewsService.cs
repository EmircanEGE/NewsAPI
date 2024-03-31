using NewsApi.Application.Dtos;

namespace NewsApi.Application.Services
{
    public interface INewsService
    {
        Task<NewsDto> Create(string title, string content, string source, string author, int categoryId);

        Task<NewsDto> Update(int id, string title, string content, string source, string author,
            int categoryId);

        Task Delete(int id);
        Task<NewsDto> GetById(int id);
        Task<List<NewsDto>> Get(string title, int? categoryId);
    }
}
