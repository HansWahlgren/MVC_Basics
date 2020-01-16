using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Basics.Models;

namespace MVC_Basics.Controllers
{
    public class PeopleController : Controller
    {
        readonly PersonService _personService = new PersonService();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Wrong
        [HttpPost]
        public IActionResult Index(string userInput)
        {
            if (userInput != null)
            {
                return PartialView("_PersonPartial", Person.FilterPeople(userInput));
            }
            else
            {
                return PartialView("_PersonPartial", _personService.All());
            }
        }

        //Correct
        [HttpGet]
        public IActionResult PersonPartialView()
        {
            //Person model = new Person();
            return PartialView("_PersonPartial", _personService.All());
        }

        //Correct
        [HttpGet]
        public IActionResult CreatePerson()
        {
            return PartialView("_CreatePartial");
        }

        //Correct
        [HttpPost]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                _personService.Create(personViewModel.Name, personViewModel.PhoneNumber, personViewModel.City);
            }
            return PartialView("_PersonPartial", _personService.All());
        }

        //Correct
        [HttpGet]
        public IActionResult RemovePerson(int id)
        {
            Person person = _personService.Find(id);
            Person.RemovePerson(person);
            return PartialView("_PersonPartial", _personService.All());
        }

        //[HttpGet]
        //public IActionResult TestEditPerson(int id)
        //{

        //}
    }
}