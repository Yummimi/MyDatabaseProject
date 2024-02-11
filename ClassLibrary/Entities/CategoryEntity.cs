using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
