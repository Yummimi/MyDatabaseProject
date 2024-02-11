using ClassLibrary.Contexts;
using ClassLibrary.Entities;

namespace ClassLibrary.Repositories;

public class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}