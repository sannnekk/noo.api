using System.Text.Json.Serialization;

namespace noo.api.Statistic.DataAbstraction
{
    [Serializable]
    public class StatisticDataBody
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = null!;

        [JsonPropertyName("value")]
        public object Value { get; set; } = null!;
    }
}
