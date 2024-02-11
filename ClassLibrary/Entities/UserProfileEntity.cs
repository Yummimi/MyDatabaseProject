
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entities;

public class UserProfileEntity
{
    [Key]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;


    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int? AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;


}
