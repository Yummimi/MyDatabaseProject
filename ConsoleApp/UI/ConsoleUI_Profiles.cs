using ClassLibrary.Entities;
using ClassLibrary.Services;

namespace ConsoleApp.UI;

public class ConsoleUI_Profiles
{
    private readonly UserProfileService _userProfileService;
    private readonly UserService _userService;
    private readonly AddressService _addressService;

    public ConsoleUI_Profiles(UserProfileService userProfileService, UserService userService, AddressService addressService)
    {
        _userProfileService = userProfileService;
        _userService = userService;
        _addressService = addressService;
    }
    public void GetUserProfileByEmail_UI()
    {
        Console.Clear();
        Console.WriteLine("Enter an email to search for: ");
        var email = Console.ReadLine()!.ToLower();
        var user = _userService.GetUserByEmail(email);
        var userProfile = _userProfileService.GetUserProfileById(user.Id);
        if (email != null)
        {
            Console.WriteLine($"User found: {user.Email}");
            Console.WriteLine($"Firstname: {userProfile.FirstName} - Lastname: {userProfile.LastName} - Address: {userProfile.Address}");
        }
        else
        {
            Console.WriteLine("User was not found");
        }


        Console.ReadKey();
    }


    public void UpdateUserProfile_UI()
    {
        Console.Clear();
        Console.Write("Enter the Email of the user you want to update: ");
        var email = Console.ReadLine()!.ToLower();
        var user = _userService.GetUserByEmail(email);
        var userProfile = _userProfileService.GetUserProfileById(user.Id);
        if (user != null)
        {
            Console.WriteLine($"User email: ({user.Email})");
            Console.WriteLine("What would you like to update with this user?");
            Console.WriteLine("Firstname, Lastname or Address?");
            var toUpdate = Console.ReadLine()!;

            if (toUpdate.ToLower() == "firstname")
            {
                Console.Write("Enter new Firstname: ");
                userProfile.FirstName = Console.ReadLine()!.ToUpper();
                _userProfileService.UpdateUserProfile(userProfile);

                Console.WriteLine($"User: {user.Email} successfully updated!");
                Console.WriteLine($"User: {userProfile.FirstName} - {userProfile.LastName}");
            }


            else if (toUpdate.ToLower() == "lastname")
            {
                Console.Write("Enter new Lastname: ");
                userProfile.LastName = Console.ReadLine()!.ToUpper();
                _userProfileService.UpdateUserProfile(userProfile);

                Console.WriteLine($"User: {user.Email} successfully updated!");
                Console.WriteLine($"User: {userProfile.FirstName} - {userProfile.LastName}");
            }

            else if (toUpdate.ToLower() == "address")
            {
                Console.Write("Enter new Address: ");

                Console.Write("Enter a streetname: ");
                var streetName = Console.ReadLine()!.ToUpper();

                Console.Write("Enter a postalcode: ");
                var postalCode = Console.ReadLine()!.ToUpper();

                Console.Write("Enter a city: ");
                var city = Console.ReadLine()!.ToUpper();

                var newAddress = _addressService.CreateAddress(streetName, postalCode, city);
                userProfile.AddressId = newAddress.Id;
                _userProfileService.UpdateUserProfile(userProfile);

                Console.WriteLine($"User: {user.Email} successfully updated!");
                Console.WriteLine($"User: {userProfile.FirstName} - {userProfile.LastName}");
            }

            else
            {
                Console.WriteLine("No user was found.");
            }

        }
        else
        {
            Console.WriteLine("Invalid input");
        }
        Console.ReadKey();
    }
}
