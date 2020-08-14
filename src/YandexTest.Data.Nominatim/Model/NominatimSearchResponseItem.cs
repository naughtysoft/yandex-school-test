using Newtonsoft.Json;

namespace YandexTest.Data.Nominatim.Model
{
    public class NominatimSearchResponseItem
    {
        [JsonProperty(PropertyName = "type")]
        public string TypeName { get; set; }

        [JsonProperty(PropertyName = "class")]
        public string ClassName { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
    }
}
