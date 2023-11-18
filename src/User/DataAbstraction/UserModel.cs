using Microsoft.EntityFrameworkCore.Diagnostics;
using noo.api.Core.DataAbstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace noo.api.User.DataAbstraction
{
    [Serializable]
    [Table("User")]
    public class UserModel : BaseModelDefinition
    {
        [Column("slug")]
        [MaxLength(512)]
        [Required]
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;

        [Column("name")]
        [MaxLength(256)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [Column("role")]
        [Required]
        [JsonPropertyName("user_role")]
        public UserRole Role { get; set; }

        [Column("username")]
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [Column("email")]
        [Required]
        [JsonPropertyName("email")]
        public string Email {  get; set; } = string.Empty;

        [Column("media_id")]        
        [JsonPropertyName("media_id")]
        public Ulid MediaId { get; set; }

        [Column("telegram_id")]
        [JsonPropertyName("telegram")]
        public string? TelegramId { get; set; }

        [Column("password_hash")]
        [MaxLength(256)]
        [Required]
        [JsonPropertyName("password_hash")]
        public byte[]? PasswordHash { get; set; }

        [Column("is_blocked")]
        [JsonPropertyName("is_blocked")]
        public bool IsBlocked {  get; set; }

        [Column("forbidden")]
        [Required]
        [JsonPropertyName("forbidden")]
        public int Forbidden {  get; set; }
    }
}
