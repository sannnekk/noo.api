using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Answer")]
    public class AnswerModel : BaseModel
    {     
        [Column("content")]
        [Required]
        public string? Content { get; set; }

        [Column("word")]
        [MaxLength(512)]
        [Required]
        public string? Word { get; set; }

        [Column("task_id")]
        [Required]
        public Ulid TaskId { get; set; }
        public TaskModel? Task { get; set; }

        [Column("assigned_work_id")]
        [Required]
        public Ulid AssignedWorkId { get; set; }
        public AssignedWorkModel? AssignedWork { get; set; }

        public List<MediaModel>? Media { get; set; }

        public List<TaskOptionModel>? TaskOptions { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement AnswerModel slug
        }
    }
}
