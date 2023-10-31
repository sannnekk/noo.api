using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    public class ImageCommentModel
    {
        [Column("id")]
        [Key]
        public Ulid Id { get; set; }

        [Column("x")]
        [Required]
        public int X { get; set; }

        [Column("y")]
        [Required]
        public int Y { get; set; }

        [Column("width")]
        [Required]
        public int Width { get; set; }

        [Column("height")]
        [Required]
        public int Height { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; } = string.Empty;

        [Column("media_id")]
        [Required]
        public Ulid MediaId { get; set; }
        public MediaModel? Media { get; set; }

        [Column("comment_id")]
        [Required]
        public Ulid CommentId { get; set; }
        public CommentModel? Comment { get; set; }                
    }
}