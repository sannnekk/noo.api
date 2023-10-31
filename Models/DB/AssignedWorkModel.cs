using api.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Assigned_work")]
    public class AssignedWorkModel : BaseModel
    {      
        [Column("student_id")]
        [Required]
        public Ulid StudentId { get; set; }
        public UserModel? Student { get; set; }

        [Column("work_id")]
        [Required]
        public Ulid WorkId { get; set; }
        public WorkModel? Work { get; set; }

        [Column("solve_status")]
        [Required]
        public SolveStatus SolveStatus { get; set; }

        [Column("check_status")]
        [Required]
        public CheckStatus CheckStatus { get; set; }

        [Column("solve_deadline_at")]
        [Required]
        public DateTime SolveDeadlineAt { get; set; }

        [Column("check_deadline_at")]
        [Required]
        public DateTime CheckDeadlineAt { get; set; }

        [Column("solved_at")]
        [Required]
        public DateTime SolvedAt { get; set; }

        [Column("checked_at")]
        [Required]
        public DateTime CkeckedAt { get; set; }

        [Column("score")]
        [Required]
        public int Score { get; set; }

        [Column("max_score")]
        [Required]
        public int MaxScore { get; set; }
      
        public List<UserModel>? Mentors { get; set; }

        public List<CommentModel>? Comments { get; set; }

        public List<AnswerModel>? Answers { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
