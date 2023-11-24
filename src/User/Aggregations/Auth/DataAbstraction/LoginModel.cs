using System.Text.Json.Serialization;

namespace noo.api.Auth.DataAbstraction
{
    [Serializable]
    public class LoginModel
    {
        [JsonPropertyName("username_or_email")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
