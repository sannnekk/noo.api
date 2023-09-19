using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enums;

namespace api.Models.DB
{
    public class TaskModel : BaseModel
    {
        [Column("work_id")]
        [Required]
        public Ulid WorkId { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("highest_score")]
        public int HighestScore { get; set; }

        [Column("type")]
        public TaskType Type { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
