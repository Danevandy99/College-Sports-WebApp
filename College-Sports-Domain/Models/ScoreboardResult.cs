namespace College_Sports_WebApp.Database.Models
{
    public class ScoreboardResult
    {
        public int Id { get; set; }
        public List<League> leagues { get; set; }
        public List<Video> videos { get; set; }
        public List<string> groups { get; set; }
        public List<Event> events { get; set; }
        public EventsDate eventsDate { get; set; }
    }

}