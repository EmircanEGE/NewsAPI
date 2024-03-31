using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Dtos;
using NewsApi.Core.Models;
using NewsApi.Data;
using NewsApi.Data.Repositories;

namespace NewsApi.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<NewsDto> Create(string title, string content, string source, string author, int categoryId)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryId).FirstOrDefaultAsync();
            if (category == null)
            {
                return new NewsDto();
            }
            var news = new News(title, content, source, author, categoryId);
            await _newsRepository.InsertAsync(news);
            await _unitOfWork.SaveChangesAsync();
            return NewsDto.Map(news);
        }

        public async Task<NewsDto> Update(int id, string title, string content, string source, string author,
            int categoryId)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == categoryId).FirstOrDefaultAsync();
            if (category == null)
            {
                return new NewsDto();
            }
            var news = await _newsRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
            if (news == null)
            {
                return new NewsDto();
            }
            news.Update(title, content, source, author, categoryId);
            _newsRepository.Update(news);
            await _unitOfWork.SaveChangesAsync();
            return NewsDto.Map(news);
        }

        public async Task Delete(int id)
        {
            var news = await _newsRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
            _newsRepository.Delete(news);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<NewsDto> GetById(int id)
        {
            var news = await _newsRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
            if (news == null)
            {
                return new NewsDto();
            }

            return NewsDto.Map(news);
        }

        public async Task<List<NewsDto>> Get(string title, int? categoryId)
        {
            var news = _newsRepository.GetAsync(x => true);
            if (!string.IsNullOrWhiteSpace(title))
            {
                news = news.Where(x => x.Title == title);
            }

            if (categoryId != null)
            {
                news = news.Where(x => x.CategoryId == categoryId);
            }
            return news.Select(x => NewsDto.Map(x)).ToList();
        }
    }
}
