using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class Image
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string alt { get; set; }
        public string caption { get; set; }
        public string credit { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public List<Peer> peers { get; set; }
    }

}