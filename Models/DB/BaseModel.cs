using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    /// <summary>
    /// Base class for all db models 
    /// </summary>
    public abstract class BaseModel
    {
        [Key]
        [Column("id")]
        public Ulid Id { get; set; }

        [Column("slug")]
        [Required]
        [MaxLength(384)]
        public string Slug { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        protected BaseModel()
        {
            GenerateSlug();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
           

        /// <summary>
        /// Algorithm for generating slug
        /// </summary>
        protected abstract void GenerateSlug();
    }
}
