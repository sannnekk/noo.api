using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace noo.api.Statistic.DataAbstraction
{
    [Serializable]
    public class StatisticRequestBody
    {
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [Required]
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        
        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }

        [Required]
        [JsonPropertyName("accuracy")]
        public string? Accuracy { get; set; }

        [JsonPropertyName("users")]
        public List<Ulid>? Users { get; set; } = new List<Ulid>();
    }
}
