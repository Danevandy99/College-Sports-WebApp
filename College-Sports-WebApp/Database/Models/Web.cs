namespace College_Sports_WebApp.Database.Models{ 

    public class Web
    {
        public Athletes athletes { get; set; }
        public Teams teams { get; set; }
        public Leagues leagues { get; set; }
        public string href { get; set; }
        public Self self { get; set; }
    }

}