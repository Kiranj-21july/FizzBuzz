using FIZZ_BUZZ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FIZZ_BUZZ.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(new FizzBuzzModel());
        }
        [HttpPost]
        public IActionResult Process(string InputValuesString)
        {
           
            var model = new FizzBuzzModel
            {
                InputValues = InputValuesString.Split(',').Select(int.Parse).ToList(),
                Results = new List<string>(),
                DivisionsPerformed = new List<string>()
            };

            foreach (var value in model.InputValues)
            {
                string result = string.Empty;
                string division = $"{value}:";

                

                if (value % 3 == 0 && value % 5 == 0)
                {
                    result = "FizzBuzz";
                }
                else if (value % 3 == 0)
                {
                    result = "Fizz";
                }
                else if (value % 5 == 0)
                {
                    result = "Buzz";
                }
                else
                {
                    result = value.ToString();
                }

                model.Results.Add(result);
                model.DivisionsPerformed.Add(division + result);
            }

            return View("Index", model);
        }
    }
    
}
