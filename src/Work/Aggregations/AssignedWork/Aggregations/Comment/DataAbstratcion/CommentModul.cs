using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Comment.DataAbstraction;

    [Serializable]
    [Table("comment")]
    public class CommentModel : BaseModelDefinition
    {

        [Column("slug")]
        [MaxLength(512)]
        [Required]
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = null!;

        [Column("content")]
        [Required]
        [JsonPropertyName("content")]
        public string Content { get; set; } = null!;

        [Column("task_id")]
        [Required]
        [JsonPropertyName("task_id")]
        public Ulid TaskId { get; set; }

        [Column("assigned_work_id")]
        [Required]
        [JsonPropertyName("assigned_work_id")]
        public Ulid AssignedWorkId { get; set; }       
    }