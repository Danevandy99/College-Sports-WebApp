using System.Collections.Generic; 
using System;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class Policy
    {
        public List<ViewingPolicy> viewingPolicies { get; set; }
        public string id { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime lastModifiedOn { get; set; }
    }

}