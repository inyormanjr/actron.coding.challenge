using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Actron.WebApi.models;
using Actron.WebApi.services;
using Microsoft.AspNetCore.Mvc;

namespace Actron.WebApi.Controllers
{
    [ApiController]
    [Route("api/v0", Name = "ChallengeController")]
    public class ChallengeController : ControllerBase
    {
        private readonly ILogger<ChallengeController> _logger;
        private readonly ActronChallengeService _actronChallengeService;
        public ChallengeController(ILogger<ChallengeController> logger, ActronChallengeService actronChallengeService)
        {
            _actronChallengeService = actronChallengeService;
            _logger = logger;
        }

        [HttpPost]
        [Route("formLargestInt")]
        [ProducesResponseType(typeof(OutputModel), 200)]
        public IActionResult FormLargestInt([FromBody] [Required] InputModel inputModel)
        {
            try 
            {
                _logger.LogDebug("Input: {input}", inputModel?.Input);
                if (inputModel == null || inputModel.Input == null || inputModel.Input.Count == 0 || inputModel.Input.Any(x => x <= 0))
                {
                    return BadRequest("Invalid input array [non-positive integers or empty array]");
                }
                var result = _actronChallengeService.FormLargestInt(inputModel.Input);
                _logger.LogDebug("Result: {result}", result);
                return Ok(new OutputModel { Output = result });

            } catch(Exception ex) 
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }
    }
}