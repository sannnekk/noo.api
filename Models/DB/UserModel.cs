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
        [MaxLength(256)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(256)]
        [Column("userName")]
        public string UserName { get; set; } = string.Empty;

        [MaxLength(128)]
        [Column("passwordHash")]
        public SHA256 PasswordHash { get; set; }

        [MaxLength(512)]
        [Column("google_token")]
        public string GoogleToken { get; set; } = string.Empty;

        [MaxLength(32)]
        [Column("telegram_id")]
        public string TelegramId { get; set; } = string.Empty;

        [Column("role")]
        public UserRole UserRole { get; set; }

        [Required]
        [Column("is_blocked")]
        public bool isBlocked { get; set; }

        [Column("forbidden")]
        public int Forbidden { get; set; }  

        protected override void GenerateSlug()
        {
            // TODO: Implement UserModel slug
        }
    }
}
