using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTSGamePoc;

namespace SlowRtsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //GET api/values
        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET api/values/5
        [HttpGet]
        public ActionResult<List<Location>> Get()
        {
            var mapGen = new MapGenerator(5, 4);

            var locations = mapGen.GenerateLocations();

            var map = new List<Location>();

            locations.ForEach(location =>
            {
                var mappedLocation = new Location
                {
                    type = location.GetType().Name.ToString(),
                    coordinate = location.coordinate,
                    connectedLocations = location.location.Select(l => new Coordinate { X = l.coordinate.X, Y = l.coordinate.Y }).ToList()
                };

                map.Add(mappedLocation);
            });

            return map;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
