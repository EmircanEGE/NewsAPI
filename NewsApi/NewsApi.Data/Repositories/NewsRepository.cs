using NewsApi.Core.Models;

namespace NewsApi.Data.Repositories;

public class NewsRepository : Repository<News>, INewsRepository
{
    public NewsRepository(Context context) : base(context)
    {
    }
}