using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {

  
        private readonly IMemoryCache _memCache;
        public InitController(IMemoryCache memCache, ILogger<InitController> logger)
        {
            _memCache = memCache;
            Logger = logger;
        }

        public ILogger Logger { get; }

        // GET: api/<InitController>
        [HttpGet]
        public IActionResult Get()
        {
            var isInit = _memCache.Get<bool>("INIT");
            Logger.LogWarning("init swap");
        
            if (isInit)
            {
              
                return Ok("Already init");
            }
            _memCache.Set("INIT", true);
            return Ok("Init finished");
        }    

    }
}
