using ClassLibrary.Contexts;
using ClassLibrary.Entities;
using ClassLibrary.Repositories;

namespace ClassLibrary.Services;

public class UserService
{
    private readonly UserRepository _userRepository;
    private readonly UserProfileRepository _userProfileRepository;
    private readonly DataContext _dataContext;

    public UserService(UserRepository userRepository, UserProfileRepository userProfileRepository, DataContext dataContext)
    {
        _userRepository = userRepository;
        _userProfileRepository = userProfileRepository;
        _dataContext = dataContext;
    }

    public UserEntity CreateUser(string email, string password)
    {
        var userEntity = new UserEntity
        {
            Email = email,
            Password = password
        };

        userEntity = _userRepository.Create(userEntity);

        var userProfileEntity = new UserProfileEntity
        {
            UserId = userEntity.Id,
            FirstName = null,
            LastName = null,
            AddressId = null
        };

        _userProfileRepository.Create(userProfileEntity);

        return userEntity;
    }

    public UserEntity GetUserById(int id)
    {
        var userEntity = _userRepository.GetOne(x => x.Id == id);
        return userEntity;
    }
    public UserEntity GetUserByEmail(string email)
    {
        var userEntity = _userRepository.GetOne(x => x.Email == email);
        return userEntity;
    }


    public IEnumerable<UserEntity> GetAllUsers()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public UserEntity UpdateUser(UserEntity userEntity)
    {
        var updatedUserEntity = _userRepository.Update(x => x.Id == userEntity.Id, userEntity);
        return updatedUserEntity;
    }

    public void DeleteUser(int id)
    {
        var userProfileEntity = _userProfileRepository.GetOne(x => x.UserId == id);
        if (userProfileEntity != null)
        {
            _userProfileRepository.Delete(x => x.UserId == id);
        }
        _userRepository.Delete(x => x.Id == id);
    }
}
