using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.DB
{
    [Table("Answer")]
    public class AnswerModel : BaseModel
    {     
        [Column("content")]
        public string? Content { get; set; }

        protected override void GenerateSlug()
        {
            // TODO: Implement AnswerModel slug
        }
    }
}
