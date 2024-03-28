using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApi.Core.Models
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public string Author { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
