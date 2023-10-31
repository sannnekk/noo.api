using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    public class TaskOptionModel
    {
        [Column("id")]
        [Key]
        public Ulid Id { get; set; }

        [Column("name")]
        [MaxLength(512)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("is_correct")]      
        [Required]
        public bool IsCorrect { get; set; }

        [Column("task_id")]
        [Required]
        public Ulid TaskId { get; set; }
        public TaskModel? Task { get; set; }

        public List<AnswerModel>? Answers { get; set; }
    }
}