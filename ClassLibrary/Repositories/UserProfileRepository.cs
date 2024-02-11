using ClassLibrary.Contexts;
using ClassLibrary.Entities;

namespace ClassLibrary.Repositories;

public class UserProfileRepository : Repo<UserProfileEntity>
{
    public UserProfileRepository(DataContext context) : base(context)
    {
    }
}
