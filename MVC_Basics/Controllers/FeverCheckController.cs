using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class FeverCheckController : Controller
    {
    //    [Route("FeverCheck")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    //    [Route("FeverCheck")]
        [HttpPost]
        public IActionResult Index(string userInput, string tempChoice)
        {
            if (userInput != null)
            {
                try
                {
                    float temperature = float.Parse(userInput);
                    ViewBag.FeverResult = CheckFever.CalculateFever(temperature, tempChoice);
                }
                catch (Exception)
                {
                    ViewBag.FeverResult = "You must enter a number";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}