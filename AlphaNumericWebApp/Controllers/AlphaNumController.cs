using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaNumericWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberServices;
using PhoneNumberServices.Models;

namespace AlphaNumericWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphaNumController : ControllerBase
    {

        private readonly IAlphaNumericGenerator _alphaNumericGenerator;

        public AlphaNumController(IAlphaNumericGenerator alphaNumericGenerator)
        {
            _alphaNumericGenerator = alphaNumericGenerator ?? throw new ArgumentNullException("alphaNumericGenerator in class AlphaNumController is not instantiated.");
        }

        [HttpPost("Generate")]
        public IActionResult GenerateCombinations([FromBody] GenerateAlphaNumRequestDto requestDto)
        {
            var results = _alphaNumericGenerator.GenerateAlphaNumCombinations(requestDto.OriginalPhoneNumber, "US");
            return Ok(results);
        }

    }
}