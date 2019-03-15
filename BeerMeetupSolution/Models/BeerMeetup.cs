namespace BeerMeetupSolution.Models
{
    using Newtonsoft.Json;
    public class BeerMeetup
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "uid")]
        public string UId { get; set; }
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }
        [JsonProperty(PropertyName = "cheers")]
        public string Cheers { get; set; }
    }
}