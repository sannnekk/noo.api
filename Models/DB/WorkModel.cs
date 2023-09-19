using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Work")]
    public class WorkModel : BaseModel
    {
        [Column("material_id")]
        [Required]
        public Ulid MaterialId { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string? Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement WorkModel slug
        }
    }
}
