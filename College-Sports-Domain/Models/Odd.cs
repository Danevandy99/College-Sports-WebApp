namespace College_Sports_WebApp.Database.Models{ 

    public class Odd
    {
        public int Id {get; set; }
        public Provider provider { get; set; }
        public string details { get; set; }
        public double overUnder { get; set; }
    }

}