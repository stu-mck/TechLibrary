using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechLibrary.Domain.Aggregagtes;

namespace TechLibrary.Controllers
{
    public class VehicleController : ApiController
    {
        [HttpGet]
        public IEnumerable<Manufacturer> Manufacturers(string name)
        {
            return new List<Manufacturer>();
        }

        //[HttpGet]
        //public IEnumerable<ModelFamily> ModelFamilies(string name)
        //{
        //    return new List<Manufacturer>();
        //}
    }
}
