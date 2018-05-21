using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace AspNetCoreApiControllerExample.Controllers
{
    [Route("api/[controller]")]
    public class WithoutApiController : ControllerBase
    {
        // GET api/withoutapi
        [HttpGet]
        public ActionResult<string> Echo(
            [FromQuery, ModelBinder(typeof(OffsetDateTimeBinder))]OffsetDateTime time)
        {
            return time.ToString();
        }
    }
}
