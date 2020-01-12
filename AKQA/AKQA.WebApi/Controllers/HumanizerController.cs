using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKQA.Bussiness.Abstract;
using AKQA.Model;
using Microsoft.AspNetCore.Mvc;

namespace AKQA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanizerController : ControllerBase
    {
        private readonly IPersonProcessor _personProcessor;

        public HumanizerController(IPersonProcessor personProcessor)
        {
            _personProcessor = personProcessor;
        }

        // POST api/humanizer
        [HttpPost]
        public ActionResult<Person> Post(Person value)
        {
            return Ok(_personProcessor.ProcessPerson(value));
        }
    }
}
