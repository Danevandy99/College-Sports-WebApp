using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Venue
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string fullName { get; set; }
        public Address address { get; set; }
        public int capacity { get; set; }
        public bool indoor { get; set; }
    }

}