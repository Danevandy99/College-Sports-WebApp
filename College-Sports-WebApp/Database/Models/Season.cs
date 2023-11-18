namespace College_Sports_WebApp.Database.Models{ 

    public class Season
    {
        public int year { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string displayName { get; set; }
        public Type type { get; set; }
        public string slug { get; set; }
    }

}