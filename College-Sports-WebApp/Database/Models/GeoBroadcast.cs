namespace College_Sports_WebApp.Database.Models{ 

    public class GeoBroadcast
    {
        public Type type { get; set; }
        public Market market { get; set; }
        public Media media { get; set; }
        public string lang { get; set; }
        public string region { get; set; }
    }

}