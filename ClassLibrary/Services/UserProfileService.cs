using ClassLibrary.Entities;
using ClassLibrary.Repositories;

namespace ClassLibrary.Services;

public class UserProfileService
{
    private readonly UserProfileRepository _userProfileRepository;
    private readonly UserService _userService;
    private readonly AddressService _addressService;

    public UserProfileService(UserProfileRepository userProfileRepository, UserService userService, AddressService addressService)
    {
        _userProfileRepository = userProfileRepository;
        _userService = userService;
        _addressService = addressService;
    }

    public UserProfileEntity CreateUserProfile(string firstName, string lastName, string streetName, string postalCode, string city)
    {
        var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);

        var userProfileEntity = new UserProfileEntity
        {
            FirstName = firstName,
            LastName = lastName,
            AddressId = addressEntity.Id
        };

        userProfileEntity = _userProfileRepository.Create(userProfileEntity);
        return userProfileEntity;
    }

    public UserProfileEntity GetUserProfileById(int id)
    {
        var userProfileEntity = _userProfileRepository.GetOne(x => x.UserId == id);
        return userProfileEntity;
    }
    public UserProfileEntity GetUserProfileByLastname(string lastname)
    {
        var userProfileEntity = _userProfileRepository.GetOne(x => x.LastName == lastname);
        return userProfileEntity;
    }

    public UserProfileEntity GetUserProfileByFirstname(string firstname)
    {
        var userProfileEntity = _userProfileRepository.GetOne(x => x.FirstName == firstname);
        return userProfileEntity;
    }

    public UserProfileEntity GetUserProfileByAddress(string streetName, string postalCode, string city)
    {
        var userProfileEntity = _userProfileRepository.GetOne(x => x.Address.StreetName == streetName && x.Address.PostalCode == postalCode && x.Address.City == city);
        return userProfileEntity;
    }

    public UserProfileEntity UpdateUserProfile(UserProfileEntity userProfileEntity)
    {
        var updatedUserProfileEntity = _userProfileRepository.Update(x => x.UserId == userProfileEntity.UserId, userProfileEntity);
        return updatedUserProfileEntity;
    }
}
