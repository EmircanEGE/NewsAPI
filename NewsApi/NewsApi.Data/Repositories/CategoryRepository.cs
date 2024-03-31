using NewsApi.Core.Models;

namespace NewsApi.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
