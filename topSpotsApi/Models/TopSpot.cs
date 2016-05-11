using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace topSpotsApi.Models
{
    public class TopSpot
    {
        public string name { get; set; }
        public string description { get; set; }
        public double[] location { get; set; }
    }
}