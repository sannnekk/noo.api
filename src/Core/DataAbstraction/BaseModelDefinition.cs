using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace noo.api.Core.DataAbstraction;

public abstract class BaseModelDefinition
{
    [Key]
    [Column("id")]
    public Ulid Id { get; set; }

    [Column("created_at")]
    [Required]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    [Required]
    public DateTime UpdatedAt { get; set; }

    protected BaseModelDefinition()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}