namespace College_Sports_WebApp.Database.Models{ 

    public class League2
    {
        public int id { get; set; }
        public string description { get; set; }
        public List<Link> links { get; set; }
    }

}