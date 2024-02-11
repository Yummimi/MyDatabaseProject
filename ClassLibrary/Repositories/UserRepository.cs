using ClassLibrary.Contexts;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

public class UserRepository : Repo<UserEntity>
{
    private readonly DataContext _context;
    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public UserEntity Create(UserEntity user, string password)
    {
        user.Password = password;
        _context.Set<UserEntity>().Add(user);
        _context.SaveChanges();

        var userProfile = new UserProfileEntity { UserId = user.Id, User = user };
        _context.Set<UserProfileEntity>().Add(userProfile);
        _context.SaveChanges();

        user.Profile = userProfile;

        return user;
    }
}
