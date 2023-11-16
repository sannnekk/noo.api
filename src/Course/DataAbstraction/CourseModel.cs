using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;
using noo.api.Course.Aggregations.CourseChapter.DataAbstraction;

namespace noo.api.Course.DataAbstraction;

[Serializable]
[Table("course")]
public class CourseModel : BaseModelDefinition
{
    [Column("name")]
    [MaxLength(255)]
    [Required]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Column("description")]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("chapters")]
    public List<CourseChapterModel> Chapters { get; set; } = new();
}

