using System.Collections.Generic; 
using System; 
namespace College_Sports_WebApp.Database.Models{ 

    public class Video
    {
        public string source { get; set; }
        public int id { get; set; }
        public string dataSourceIdentifier { get; set; }
        public string headline { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public bool premium { get; set; }
        public Ad ad { get; set; }
        public Tracking tracking { get; set; }
        public string cerebroId { get; set; }
        public string contributingPartner { get; set; }
        public string contributingSystem { get; set; }
        public DateTime lastModified { get; set; }
        public DateTime originalPublishDate { get; set; }
        public TimeRestrictions timeRestrictions { get; set; }
        public DeviceRestrictions deviceRestrictions { get; set; }
        public bool syndicatable { get; set; }
        public int duration { get; set; }
        public List<Category> categories { get; set; }
        public List<string> keywords { get; set; }
        public PosterImages posterImages { get; set; }
        public List<Image> images { get; set; }
        public string thumbnail { get; set; }
        public string title { get; set; }
    }

}