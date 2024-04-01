namespace NewsApi.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }

        public Category()
        {
            
        }

        public Category(string name)
        {
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
