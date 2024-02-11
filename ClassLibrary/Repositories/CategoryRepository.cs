using ClassLibrary.Contexts;
using ClassLibrary.Entities;

namespace ClassLibrary.Repositories;

public class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
