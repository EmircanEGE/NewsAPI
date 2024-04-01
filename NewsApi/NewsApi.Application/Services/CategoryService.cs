using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Dtos;
using NewsApi.Core.Models;
using NewsApi.Data;
using NewsApi.Data.Repositories;

namespace NewsApi.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> Create(string name)
        {
            var category = new Category(name);
            await _categoryRepository.InsertAsync(category);
            await _unitOfWork.SaveChangesAsync();
            return CategoryDto.Map(category);
        }

        public async Task<CategoryDto> Update(int id, string name)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return new CategoryDto();
            }
            category.Update(name);
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync();
            return CategoryDto.Map(category);
        }

        public async Task Delete(string name)
        {
            var result =  await _categoryRepository.GetAsync(x => x.Name == name).FirstOrDefaultAsync();
            _categoryRepository.Delete(result);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryRepository.GetAsync(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return new CategoryDto();
            }
            return CategoryDto.Map(category);
        }

        public async Task<List<CategoryDto>> Get(string name)
        {
            var categories = _categoryRepository.GetAsync(x => true);
            if (!string.IsNullOrWhiteSpace(name))
            {
                categories = categories.Where(x => x.Name == name);
            }
            return categories.Select(x => CategoryDto.Map(x)).ToList();
        }
    }
}
