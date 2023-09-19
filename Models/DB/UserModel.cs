using api.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace api.Models.DB
{
    [Serializable]
    [Table("User")]
    public class UserModel : BaseModel
    {
        [Key]
        [Column("id")]
        public override Ulid Id { get; set; }

        [MaxLength(384)]
        [Required]
        [Column("slug")]
        public override string Slug { get; }

        [MaxLength(256)]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(256)]
        [Column("userName")]
        public string UserName { get; set; }

        [MaxLength(128)]
        [Column("passwordHash")]
        public SHA256 PasswordHash { get; set; }

        [MaxLength(512)]
        [Column("google_token")]
        public string GoogleToken { get; set; }

        [MaxLength(32)]
        [Column("telegram_id")]
        public string TelegramId { get; set; }

        [Column("role")]
        public UserRole UserRole { get; set; }

        [Required]
        [Column("is_blocked")]
        public bool isBlocked { get; set; }

        [Column("forbidden")]
        public int Forbidden { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        protected override void GenerateSlug()
        {
            // TODO: Implement UserModel slug
        }
    }
}
