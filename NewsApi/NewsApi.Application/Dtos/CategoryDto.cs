using NewsApi.Core.Models;

namespace NewsApi.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public static CategoryDto Map(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreatedDateTime = category.CreatedDate,
                UpdatedDateTime = category.UpdatedDate
            };
        }
    }
}
