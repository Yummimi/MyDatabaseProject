using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public UserProfileEntity Profile { get; set; } = null!;
}
