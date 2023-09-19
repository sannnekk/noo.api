using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Assigned_work")]
    public class AssignedWorkModel : BaseModel
    {
        [Column("mentor_id")]
        [Required]
        public Ulid MentorId { get; set; }

        [Column("student_id")]
        [Required]
        public Ulid StudentId { get; set; }

        [Column("work_id")]
        [Required]
        public Ulid WorkId { get; set; }

        [Column("deadline_at")]
        public DateTime DeadLineAt { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
