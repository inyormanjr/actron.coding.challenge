using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actron.WebApi.models;
using Microsoft.AspNetCore.Mvc;

namespace Actron.WebApi.Controllers
{
    [ApiController]
    [Route("api/v0")]
    public class ChallengeController : ControllerBase
    {
        [HttpPost]
        [Route("formLargestInt")]
        public IActionResult FormLargestInt([FromBody] InputModel inputModel)
        {
            if(inputModel == null || inputModel.Input == null || inputModel.Input.Count == 0 || inputModel.Input.Any(x => x <= 0))   
            {
                return BadRequest("Invalid input array [non-positive integers or empty array]");
            }
  
            string[] numberString = inputModel.Input.Select(x => x.ToString()).ToArray();
            Array.Sort(numberString, (x, y) => (y + x).CompareTo(x + y));
            var result = string.Join("", numberString);
            return Ok(new OutputModel { Output = result });
        }
    }
}