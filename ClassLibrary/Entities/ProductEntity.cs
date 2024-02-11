using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Required]

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

}
