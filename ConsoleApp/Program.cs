using System;
using ClassLibrary.Contexts;
using ClassLibrary.Repositories;
using ClassLibrary.Services;
using ConsoleApp.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\School\Databases\MyDatabaseProject\ClassLibrary\Data\Database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

        /*services.AddScoped<AddressRepository>();
        services.AddScoped<CategoryRepository>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<UserProfileRepository>();

        services.AddScoped<AddressService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<ProductService>();
        services.AddScoped<UserService>();
        services.AddScoped<UserProfileService>();

        services.AddSingleton<ConsoleUI_Products>();
        services.AddSingleton<ConsoleUI_Users>();
        services.AddSingleton<ConsoleUI_Categories>();
        services.AddSingleton<ConsoleUI_Profiles>();*/

    }).Build();

//Jag hann ej göra en user-interface eller en "meny", so kör dessa i den ordning som du önskar. Jag kommenterar ut alla så länge.

//var consoleUIProducts = builder.Services.GetRequiredService<ConsoleUI_Products>();
//consoleUIProducts.CreateProduct_UI();
//consoleUI.GetProducts_UI();
//consoleUI.UpdateProduct_UI();
//consoleUI.DeleteProduct_UI();

//var consoleUIUsers = builder.Services.GetRequiredService<ConsoleUI_Users>();
//consoleUIUsers.CreateUser_UI();
//consoleUIUsers.GetAllUsers_UI();
//consoleUIUsers.GetUsersByEmail_UI();
//consoleUIUsers.UpdateUser_UI();
//consoleUIUsers.DeleteUser_UI();

//var consoleUICategories = builder.Services.GetRequiredService<ConsoleUI_Categories>();
//consoleUICategories.CreateCategory_UI();
//consoleUICategories.GetCategories_UI();
//consoleUICategories.UpdateCategory_UI();

var consoleUIProfiles = builder.Services.GetRequiredService<ConsoleUI_Profiles>();
//consoleUIProfiles.UpdateUserProfile_UI();
//consoleUIProfiles.GetUserProfileByEmail_UI();