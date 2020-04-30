using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomActionFilterAttribute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        // action always allowed
        [HttpGet("1")]
        public string Get1()
        {
            return $"{nameof(Get1)}";
        }

        // action only allowed if Get2EndpointEnabled feature toggle is enabled (currently enabled in config)
        [HttpGet("2")]
        [FeatureGate(FeatureToggles.Get2EndpointEnabled)]
        public string Get2()
        {
            return $"{nameof(Get2)}";
        }

        // action only allowed if Get3EndpointEnabled feature toggle is enabled (currently disabled in config)
        [HttpGet("3")]
        [FeatureGate(FeatureToggles.Get3EndpointEnabled)]
        public string Get3()
        {
            return $"{nameof(Get3)}";
        }
    }
}