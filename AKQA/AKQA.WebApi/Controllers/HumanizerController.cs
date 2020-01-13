﻿using AKQA.Bussiness.Abstract;
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
        /// <summary>
        /// processing a Person and adds a humanized vesrion of the number to it
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Person> Post(Person value)
        {
            return Ok(_personProcessor.ProcessNumberIntoWords(value));
        }
    }
}
