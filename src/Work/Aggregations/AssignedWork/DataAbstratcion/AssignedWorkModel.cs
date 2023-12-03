using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using noo.api.Core.DataAbstraction;
using noo.api.Work.DataAbstraction;

namespace noo.api.Work.Aggregations.AssignedWork.DataAbstraction;

    [Serializable]
    [Table("assigned_work")]
    public class AssignedWorkModel : BaseModelDefinition
    {

        [Column("slug")]
        [MaxLength(512)]
        [Required]
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = null!;

        [Column("student_id")]
        [Required]
        [JsonPropertyName("student_id")]
        public Ulid StudentId { get; set; }

        [Column("work_id")]
        [Required]
        [JsonPropertyName("work_id")]
        public Ulid WorkId { get; set; }

        [Column("solve_status")]
        [Required]
        [JsonPropertyName("solve_status")]
        public SolveStatusEnum SolveStatus { get; set; }

        [Column("check_status")]
        [Required]
        [JsonPropertyName("check_status")]
        public CheckStatusEnum CheckStatus { get; set; }

        [Column("solve_deadline_at")]
        [Required]
        [JsonPropertyName("solve_deadline_at")]
        public DateTime SolveDeadlineAt { get; set; }

        [Column("check_deadline_at")]
        [Required]
        [JsonPropertyName("check_deadline_at")]
        public DateTime CheckDeadlineAt { get; set; }

        [Column("solved_at")]
        [JsonPropertyName("solved_at")]
        public DateTime? SolvedAt { get; set; }

        [Column("checked_at")]
        [JsonPropertyName("checked_at")]
        public DateTime? CheckedAt { get; set; }

        [Column("score")]
        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [Column("max_score")]
        [Required]
        [JsonPropertyName("max_score")]
        public int? MaxScore { get; set; }
    }