using System.Collections.Generic; 
using System; 
namespace College_Sports_WebApp.Database.Models{ 

    public class Properties
    {
        public string hasEspnId3Heartbeats { get; set; }
        public string language { get; set; }
        public string shortTitle { get; set; }
        public string trueOriginal { get; set; }
        public string title { get; set; }
        public string simulcastAiringId { get; set; }
        public string contentCleared { get; set; }
        public string hasPassThroughAds { get; set; }
        public List<string> dtcPackages { get; set; }
        public string airingConcurrency { get; set; }
        public string isLive { get; set; }
        public string hasNielsenWatermarks { get; set; }
        public string artworkLastModified { get; set; }
        public string allowStartOver { get; set; }
        public string trackingId { get; set; }
        public string commercialReplacement { get; set; }
        public string allowedAccess { get; set; }
        public string reAir { get; set; }
        public DateTime killDateTimestamp { get; set; }
        public string sponsored { get; set; }
        public string liveReplay { get; set; }
        public string broadcastStartOffset { get; set; }
        public DateTime nbStartTimestamp { get; set; }
        public string feedType { get; set; }
        public string ratingsId { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string canIpAuthenticate { get; set; }
        public string origination { get; set; }
        public List<string> iso3166 { get; set; }
        public List<string> subscription { get; set; }
    }

}