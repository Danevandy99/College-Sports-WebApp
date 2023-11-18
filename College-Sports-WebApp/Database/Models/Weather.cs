namespace College_Sports_WebApp.Database.Models{ 

    public class Weather
    {
        public string displayValue { get; set; }
        public int temperature { get; set; }
        public int highTemperature { get; set; }
        public string conditionId { get; set; }
        public Link link { get; set; }
    }

}