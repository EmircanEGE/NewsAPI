using NewsApi.Core.Models;

namespace NewsApi.Application.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        
        public CategoryDto Category { get; set; }

        public static NewsDto Map(News news)
        {
            return new NewsDto()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                Source = news.Source,
                Author = news.Author,
                Category = CategoryDto.Map(news.Category),
                CreatedDateTime = news.CreatedDate,
                UpdatedDateTime = news.UpdatedDate
            };
        }
    }
}
