using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enums;

namespace api.Models.DB
{
    public class TaskModel : BaseModel
    {
        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("highest_score")]
        [Required]
        public int HighestScore { get; set; }

        [Column("type")]
        [Required]
        public TaskType Type { get; set; }

        [Column("right_answer")]
        [Required]
        public string RightAnswer = string.Empty;

        [Column("work_id")]
        [Required]
        public Ulid WorkId { get; set; }
        public WorkModel? Work { get; set; }

        public List<AnswerModel>? Answers { get; set; }

        public List<TaskOptionModel>? TaskOptions { get; set; }

        public List<CommentModel>? Comments { get; set; }

        public List<MediaModel>? Media { get; set; }
     
        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
