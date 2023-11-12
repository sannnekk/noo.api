using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;

namespace noo.api.Material.DataAbstraction;

[Serializable]
[Table("material")]
public class MaterialModel : BaseModelDefinition
{
    [Column("name")]
    [MaxLength(255)]
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Column("description")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Column("content")]
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [Column("chapter_id")]
    [Required]
    [JsonPropertyName("chapter_id")]
    public Ulid ChapterId { get; set; }
}

