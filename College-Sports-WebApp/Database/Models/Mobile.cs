namespace College_Sports_WebApp.Database.Models{ 

    public class Mobile
    {
        public Athletes athletes { get; set; }
        public Teams teams { get; set; }
        public Leagues leagues { get; set; }
        public Alert alert { get; set; }
        public Source source { get; set; }
        public string href { get; set; }
        public Streaming streaming { get; set; }
        public ProgressiveDownload progressiveDownload { get; set; }
    }

}