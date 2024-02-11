
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entities;

public class AddressEntity
{
    [Key]

    public int Id { get; set; }

    [StringLength(50)]
    public string StreetName { get; set; } = null!;

    [StringLength(20)]
    public string PostalCode { get; set; } = null!;

    [StringLength(20)]
    public string City { get; set; } = null!;

    public ICollection<UserProfileEntity> Profiles { get; set; } = new List<UserProfileEntity>();

}
