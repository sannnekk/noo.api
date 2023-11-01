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
        [Column("name")]
        [MaxLength(256)]     
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("role")]
        [Required]
        public UserRole UserRole { get; set; }

        [Column("userName")]
        [MaxLength(256)]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Column("userName")]
        [MaxLength(256)]
        [Required]
        public string Email { get; set; } = string.Empty;
       
        [Column("media_id")]      
        [Required]
        public Ulid MediaId { get; set; }
        public MediaModel? Media { get; set; }

        [Column("telegram_id")]
        [MaxLength(64)]
        [Required]
        public string TelegramId { get; set; } = string.Empty;

        [Column("passwordHash")]
        [MaxLength(256)]
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
             
        [Column("is_blocked")]
        [Required]       
        public bool isBlocked { get; set; }

        [Column("forbidden")]
        [Required]
        public int Forbidden { get; set; }  

        public List<CourseModel>? Courses { get; set; }

        public List<AssignedWorkModel>? AssignedWorks { get; set; }
      
        protected override void GenerateSlug()
        {
            // TODO: Implement UserModel slug
        }
    }
}
