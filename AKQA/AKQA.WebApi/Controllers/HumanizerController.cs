using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKQA.Model;
using Microsoft.AspNetCore.Mvc;

namespace AKQA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanizerController : ControllerBase
    {
        // POST api/humanizer
        [HttpPost]
        public ActionResult<Person> Post(Person value)
        {
            value.HumanizedNumber = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS";
            return value;
        }
    }
}
