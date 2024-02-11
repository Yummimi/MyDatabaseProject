using ClassLibrary.Contexts;
using ClassLibrary.Entities;

namespace ClassLibrary.Repositories;

public class ProductRepository : Repo<ProductEntity>
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
