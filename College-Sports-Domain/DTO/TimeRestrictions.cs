using System;
using Microsoft.EntityFrameworkCore;
namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class TimeRestrictions
    {
        public DateTime embargoDate { get; set; }
        public DateTime expirationDate { get; set; }
    }

}