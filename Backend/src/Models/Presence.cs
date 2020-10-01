using System;
using System.Text.Json.Serialization;

namespace AspnetWorkerService.Models
{
    public class Presence
    {
        [JsonPropertyName("@odata.context")]
        public string DataContext { get; set; }

        public string Id { get; set; }

        public string Availability { get; set; }

        public string Activity { get; set; }
    }
}
