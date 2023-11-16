using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;
using noo.api.Course.DataAbstraction;

namespace noo.api.Course.Aggregations.CourseChapter.DataAbstraction;

[Serializable]
[Table("course_chapter")]
public class CourseChapterModel : BaseModelDefinition
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
    public string Name { get; set; } = null!;

    [ForeignKey("course_id")]
    [JsonPropertyName("course_id")]
    public CourseModel Course { get; set; } = null!;
}