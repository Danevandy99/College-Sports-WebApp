using System.Text.Json.Serialization;
using College_Sports_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{
    [Owned]
    public class PosterImages
    {
        [JsonPropertyName("default")]
        public Default @default { get; set; }
        public HrefWrapper full { get; set; }
        public HrefWrapper wide { get; set; }
        public HrefWrapper square { get; set; }
    }

}