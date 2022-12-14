using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorld : ControllerBase
    {
        public HelloWorld() { }
        [AcceptVerbs("Get")]
        [HttpGet("{name}")]
        [Route("Hello")]
        public ActionResult<string> SayHello(string name)
        {
            return "Hello " + name;
        }
        
    }
}