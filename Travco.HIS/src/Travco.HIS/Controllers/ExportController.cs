using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Travco.Helpers.HIS;

namespace Travco.HIS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ExportController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly Exporter _exporter;

        public ExportController(ILogger<ExportController> logger, IMapper mapper, Exporter exporter)
        {
            _mapper = mapper;
            _logger = logger;
            _exporter = exporter;
        }

        [HttpPost("start")]
        public IActionResult Start()
        {
            _exporter.Go();
            return Status();
        }

        [HttpPost("cancel")]
        public IActionResult Cancel()
        {
            _exporter.Cancel();
            return Status();
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Json(_exporter.Progress);
        }
    }
}
