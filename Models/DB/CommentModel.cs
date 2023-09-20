using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Comment")]
    public class CommentModel : BaseModel
    {
        [Column("content")]
        public string? Content { get; set; }

        [Column("score")]
        public int Score { get; set; }
        
        protected override void GenerateSlug()
        {
            // TODO: Implement CommentModel slug
        }
    }
}
