using ClassLibrary.Services;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace ConsoleApp.UI;

public class ConsoleUI_Users
{
    private readonly UserService _userService;

    public ConsoleUI_Users(UserService userService)
    {
        _userService = userService;
    }

    public void CreateUser_UI()
    {
        Console.Clear();
        var regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
        Console.WriteLine("----- Register User -----");
        Console.Write("Enter an email address: ");
        var email = Console.ReadLine()!;

        if (email != null)
        {
            Console.WriteLine("Enter a password: ");
            var password = Console.ReadLine()!;
            if (!Regex.IsMatch(password, regex))
            {
                Console.WriteLine("Password does not meet the requirements.");
                return;
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(email);
            _userService.CreateUser(email, hashedPassword);
            Console.WriteLine($"User {email} was successfully created!");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("No valid username was entered.");
        }
    }

    public void GetAllUsers_UI()
    {
        Console.Clear();
        Console.WriteLine("List of users: ");

        var users = _userService.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id} - Email: {user.Email}");
        }

        Console.ReadKey();
    }

    public void GetUsersByEmail_UI()
    {
        Console.Clear();
        Console.WriteLine("Enter an email to search for: ");
        var email = Console.ReadLine()!;
        if (email != null)
        {
            var user = _userService.GetUserByEmail(email);
            Console.WriteLine($"User found: {user.Email}");
        }
        else
        {
            Console.WriteLine("User was not found");
        }


        Console.ReadKey();
    }

    public void UpdateUser_UI()
    {
        Console.Clear();
        Console.Write("Enter the Email of the user you want to update: ");
        var email = Console.ReadLine()!;
        var user = _userService.GetUserByEmail(email);
        if (user != null)
        {
            Console.WriteLine($"User email: ({user.Email})");
            Console.WriteLine("What would you like to update with this user?");
            Console.WriteLine("Email or Password?");
            var toUpdate = Console.ReadLine()!;

            if (toUpdate.ToLower() == "email")
            {
                Console.Write("Enter new email: ");
                user.Email = Console.ReadLine()!.ToUpper();
                _userService.UpdateUser(user);

                Console.WriteLine($"User: {user.Email} successfully updated!");
            }


            else if (toUpdate.ToLower() == "password")
            {
                Console.Write("Enter new password: ");
                var password = Console.ReadLine()!;

                Console.Write("Confirm password: ");
                var confirmedPassword = Console.ReadLine()!;

                if(password == confirmedPassword)
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                    user.Password = hashedPassword;
                    _userService.UpdateUser(user);

                    Console.WriteLine($"User: {user.Email} successfully updated!");
                }
                else
                {
                    Console.WriteLine("Password did not match.");
                }
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("No user was found.");
            }
            Console.ReadKey();

        }
    }

    public void DeleteUser_UI()
    {
        Console.Clear();
        Console.Write("Enter the Id of the user you want to delete: ");
        int id = int.Parse(Console.ReadLine()!);
        var user = _userService.GetUserById(id);
        if (id > 0)
        {
            _userService.DeleteUser(id);
            Console.WriteLine($"User ({user.Email}) was succesfully removed");
        }
        else
        {
            Console.WriteLine("User was not found.");
        }
        Console.ReadKey();
    }
}
