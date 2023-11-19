namespace College_Sports_WebApp.Database.Models
{

    public class Statistic
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayValue { get; set; }
        public string rankDisplayValue { get; set; }
    }

}