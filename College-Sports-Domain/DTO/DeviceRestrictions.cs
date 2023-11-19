using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace College_Sports_WebApp.Database.Models
{

    public class DeviceRestrictions
    {
        public int Id { get; set; }
        public string type { get; set; }
        public List<string> devices { get; set; }
    }

}