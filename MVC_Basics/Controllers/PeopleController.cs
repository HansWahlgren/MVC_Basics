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
            return View(_personService.All());
        }

        [HttpPost]
        public IActionResult Index(string userInput)
        {
            if (userInput != null)
            {
                return View(Person.FilterPeople(userInput));
            }
            else
            {
                return View(_personService.All());
            }
        }

        //[HttpGet]
        //public IActionResult PersonPartialView()
        //{
        //    Person model = new Person();
        //    return PartialView("_PeoplePartialView", model);
        //}

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                _personService.Create(personViewModel.Name, personViewModel.PhoneNumber, personViewModel.City);
                return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        [HttpGet]
        public IActionResult RemovePerson(int id)
        {
            Person person = _personService.Find(id);
            Person.RemovePerson(person);
            return RedirectToAction("Index");
        }
    }
}