using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class GuessingGameController : Controller
    {
    //    [Route("GuessingGame")]
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32(SessionModel.SessionRandom_Number, CheckGuess.CreateNumber());
            HttpContext.Session.SetInt32(SessionModel.Session_Guesses, 0);
            return View();
        }

     //   [Route("GuessingGame")]
        [HttpPost]
        public IActionResult Index(string userInput)
        {
            if (userInput != null)
            {
                try
                {
                    int? userNumber = int.Parse(userInput);
                    int? randomNumber = HttpContext.Session.GetInt32(SessionModel.SessionRandom_Number);
                    string guessResult = CheckGuess.CompareGuess(userNumber, randomNumber);


                    int guesses = HttpContext.Session.GetInt32(SessionModel.Session_Guesses).Value + 1;
                    ViewBag.guesses = guesses;
                    HttpContext.Session.SetInt32(SessionModel.Session_Guesses, guesses);


                    switch (guessResult)
                    {
                        case "low":
                            ViewBag.guessResult = "Your guess was to low";
                            break;
                        case "high":
                            ViewBag.guessResult = "Your guess was to high";
                            break;
                        case "correct":
                            ViewBag.guessResult = "Your guess was correct! Guess the new number!";
                            HttpContext.Session.SetInt32(SessionModel.SessionRandom_Number, CheckGuess.CreateNumber());
                            HttpContext.Session.SetInt32(SessionModel.Session_Guesses, 0);
                            break;
                    }
                }
                catch (Exception)
                {
                    ViewBag.GuessResult = "You must enter a number between 1-100";
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