using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class DeviceRestrictions
    {
        public string type { get; set; }
        public List<string> devices { get; set; }
    }

}