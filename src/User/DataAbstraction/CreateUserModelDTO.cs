using System.Text.Json.Serialization;

namespace noo.api.User.DataAbstraction
{
    [Serializable]
    public class CreateUserModelDTO
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
