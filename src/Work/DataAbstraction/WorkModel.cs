using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;
using noo.api.Work.Aggregations.WorkTask.DataAbstraction;

namespace noo.api.Work.DataAbstraction;

[Serializable]
[Table("work")]
public class WorkModel : BaseModelDefinition
{
    [Column("slug")]
    [MaxLength(512)]
    [Required]
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = null!;

    [Column("name")]
    [MaxLength(255)]
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Column("description")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Column("deadline")]
    [Required]
    [JsonPropertyName("deadline")]
    public DateTime Deadline { get; set; }

    [JsonPropertyName("tasks")]
    public List<WorkTaskModel> Tasks { get; set; } = new(); 
}

