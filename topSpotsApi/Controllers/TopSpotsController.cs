using System;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using topSpotsApi.Models;
using System.Text;
using System.IO;
using System.Web.Http.Cors;

namespace topSpotsApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class TopSpotsController : ApiController
    {
        // GET: api/TopSpots
        public IEnumerable<TopSpot> Get()
        {
            string json = File.ReadAllText(@"C:\dev\topspots.json");
            TopSpot[] result = Newtonsoft.Json.JsonConvert.DeserializeObject<TopSpot[]>(json);
            return result;
        }

        // GET: api/TopSpots/5
        public TopSpot Get(int id)
        {
            return new TopSpot
            {
                name = "Go For A Run In The San Diego Zoo Safari Park"
            };
        }

        // POST: api/TopSpots
        public TopSpot Post(TopSpot topspot)
        {
            //This will involve reading the JSON from the file system, 
            string json = File.ReadAllText(@"C:\dev\topspots.json");
            TopSpot[] result = Newtonsoft.Json.JsonConvert.DeserializeObject<TopSpot[]>(json);

            //adding a TopSpot 
            //convert to list
            List<TopSpot> topList = new List<TopSpot>(result);
            //list.add
            topList.Add(topspot);

            //and then saving the array back to the file system.
            string NewJson = Newtonsoft.Json.JsonConvert.SerializeObject(topList);
            File.WriteAllText(@"C:\dev\topspots.json", NewJson);


            return topspot;
        }

        // PUT: api/TopSpots/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TopSpots/5
        public void Delete(int id)
        {
        }
    }
}
