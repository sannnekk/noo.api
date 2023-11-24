using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;
using noo.api.Work.DataAbstraction;

namespace noo.api.Work.Aggregations.WorkTask.DataAbstraction;

    [Serializable]
    [Table("work_task")]
    public class WorkTaskModel : BaseModelDefinition
    {
        // [Column("name")]
        // [MaxLength(255)]
        // [JsonPropertyName("name")]
        // public string? Name { get; set; } = null!;

        [Column("type")]
        [Required]
        [JsonPropertyName("type")]
        public WorkTaskType Type { get; set; }

        [Column("max_points")]
        // ? MaxLength
        [Required]
        [JsonPropertyName("max_points")]
        public int MaxPoints { get; set; }

        [Column("points")]
        // ? MaxLength
        [JsonPropertyName("points")]
        public int points { get; set; }

        [Column("comment")] // ? should include an image
        [JsonPropertyName("comment")]
        public string Comment { get; set; } = null!;

        [Column("work_id")]
        [JsonPropertyName("work_id")]
        [Required]
        public Ulid WorkId { get; set; }
    }