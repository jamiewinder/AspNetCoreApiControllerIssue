using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NodaTime;

namespace AspNetCoreApiControllerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithApiController : ControllerBase
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
