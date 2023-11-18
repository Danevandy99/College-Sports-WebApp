using System.Collections.Generic; 
using System; 
namespace College_Sports_WebApp.Database.Models{ 

    public class Airing
    {
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime lastModifiedOn { get; set; }
        public string artworkUrl { get; set; }
        public string externalId { get; set; }
        public Properties properties { get; set; }
        public ProductLinks productLinks { get; set; }
        public string id { get; set; }
        public string program { get; set; }
        public string playableUrl { get; set; }
        public string policyUrl { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string network { get; set; }
        public string networkId { get; set; }
        public Policy policy { get; set; }
        public bool withinPlayWindow { get; set; }
        public List<Image> images { get; set; }
        public string network_shortName { get; set; }
        public string network_displayName { get; set; }
        public string program_language { get; set; }
        public string program_eventId { get; set; }
        public string program_eventUrl { get; set; }
        public string program_shortTitle { get; set; }
        public DateTime program_originalAirDate { get; set; }
        public DateTime program_firstPresented { get; set; }
        public string webAiringLink { get; set; }
        public string appAiringLink { get; set; }
        public List<ProgramCategory> program_categories { get; set; }
        public string webGameLink { get; set; }
        public string appGameLink { get; set; }
    }

}