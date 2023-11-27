using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.Aggregations.Answer.DataAbstraction;

    [Serializable]
    [Table("answer")]
    public class AnswerModel : BaseModelDefinition
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

        [Column("word")]
        [MaxLength(512)]
        [Required]
        [JsonPropertyName("word")]
        public string Word { get; set; } = null!;

        [Column("assigned_work_id")]
        [Required]
        [JsonPropertyName("assigned_work_id")]
        public Ulid AssignedWorkId { get; set; }       
    }