using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            collection.TryGetValue("lengthBox", out Microsoft.Extensions.Primitives.StringValues lengthValue);
            collection.TryGetValue("fuzzBox", out Microsoft.Extensions.Primitives.StringValues fuzzValue);
            collection.TryGetValue("jazzBox", out Microsoft.Extensions.Primitives.StringValues jazzValue);
            collection.TryGetValue("backwardsBox", out Microsoft.Extensions.Primitives.StringValues backwardsValue);
            int length = 0;
            try
            {
                length = int.Parse(lengthValue.ToString());
            }
            catch(Exception e)
            {
                length = 100;
            }
            var fuzz = !fuzzValue.ToString().Equals("false");
            var jazz = !jazzValue.ToString().Equals("false");
            var backwards = !backwardsValue.ToString().Equals("false");

            var fizzBuzz = new FizzBuzzService(length, fuzz, jazz, backwards);

            var results = fizzBuzz.GetFizzBuzzResult();

            return View("Index", new FormModel() { Length = length, Fuzz = fuzz, Jazz = jazz, Backwards = backwards, Results = results });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
