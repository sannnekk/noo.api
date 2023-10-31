using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Work")]
    public class WorkModel : BaseModel
    {      
        [Column("name")]
        [MaxLength(255)]
        [Required]
        public string? Name { get; set; }

        [Column("description")]
        [Required]
        public string? Description { get; set; }

        [Column("material_id")]
        [Required]
        public Ulid MaterialId { get; set; }
        public MaterialModel? Material { get; set; }

        public List<AssignedWorkModel>? AssignedWorks { get; set; }

        public List<TaskModel>? Tasks { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
