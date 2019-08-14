using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaNumericWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberServices;
using PhoneNumberServices.Models;

namespace AlphaNumericWebApp.Controllers
{
    
    public class PhoneNumberController : Controller
    {
        private readonly IAlphaNumericGenerator _alphaNumericGenerator;

        public PhoneNumberController(IAlphaNumericGenerator alphaNumericGenerator)
        {
            _alphaNumericGenerator = alphaNumericGenerator ?? throw new ArgumentNullException("alphaNumericGenerator in class PhoneNumberController is not instantiated.");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GenerateCombinations(PhoneNumberViewModel model)
        {
            var alphaNumViewModel = new GenerateAlphaNumResponseDto();

            if (ModelState.IsValid)
            {
                try
                {
                    var generationResponse = _alphaNumericGenerator.GenerateAlphaNumCombinations(model.OriginalPhoneNumber, "US");

                    if(generationResponse.Success == false)
                    {

                        ModelState.AddModelError("Failed to generate alpha-numbers. ", generationResponse.ErrorsToString());
                        return View("Index", model);
                    }

                    alphaNumViewModel = generationResponse.Data;

                    

                    return View("AlphaNumbers", alphaNumViewModel);
                }
                catch (Exception ex)
                {
                    //Adding errors to ModelState and ModelState.IsValid will be changed to false

                    ModelState.AddModelError(ex.ToString(), ex.Message);
                    return View("Index", model);
                }
            }

            

            return View("Index", model);
        }
    }
}