using System.Text.Json.Serialization;

namespace noo.api.Statistic.DataAbstraction
{
    [Serializable]
    public class StatisticResponseBody
    {
        [JsonPropertyName("userId")]
        public Ulid UserId { get; set; }

        [JsonPropertyName("data")]
        public List<StatisticDataBody> Data { get; set; } = new List<StatisticDataBody>();
    }
}
