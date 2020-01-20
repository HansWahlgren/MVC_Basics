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

        //Correct
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
                _personService.Create(personViewModel);
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

        //Correct
        [HttpGet]
        public IActionResult FormEditPerson(int id)
        {
            Person person = _personService.Find(id);

            return PartialView("_EditPartial", person);
        }

        //Correct
        [HttpPost]
        public IActionResult EditPerson(PersonViewModel personViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                _personService.Update(personViewModel, id);
            }
            return PartialView("_PersonPartial", _personService.All());
        }
    }
}