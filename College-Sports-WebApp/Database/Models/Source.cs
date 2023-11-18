namespace College_Sports_WebApp.Database.Models{ 

    public class Source
    {
        public Mezzanine mezzanine { get; set; }
        public Flash flash { get; set; }
        public Hds hds { get; set; }
        public HLS HLS { get; set; }
        public HD HD { get; set; }
        public Full full { get; set; }
        public string href { get; set; }
    }

}