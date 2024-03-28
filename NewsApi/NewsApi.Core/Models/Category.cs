namespace NewsApi.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
