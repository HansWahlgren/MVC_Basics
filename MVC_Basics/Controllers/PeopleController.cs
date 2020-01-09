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
        //[HttpGet]
        //public async Task<IActionResult> IndexAsync()
        //{
        //    //    return View(PersonViewModel.personList);
        //    //    return View(Person.personList);
        //    Person model = new Person();
        //    //var test = await Html.PartialAsync("_AuthorPartial", model);
        //    //return PartialView("_PeoplePartialView", model);

        //    return View("Index", "_PeoplePartialView");

        //    //return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            //    return View(PersonViewModel.personList);
            //    return View(Person.personList);
            //Person model = new Person();
            //var test = await Html.PartialAsync("_AuthorPartial", model);
            //return PartialView("_PeoplePartialView", model);

            //return View("Index", "_PeoplePartialView");

            return View();
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
                return View(PersonViewModel.personList);
            }
        }

        [HttpGet]
        public IActionResult GetPartialView()
        {
            Person model = new Person();
            return PartialView("_PeoplePartialView", model);
        }

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
                PersonViewModel.personList.Add(
                    new Person()
                    {
                        Id = PersonSequencer.NextPersonId(),
                        Name = personViewModel.Name,
                        PhoneNumber = personViewModel.PhoneNumber,
                        City = personViewModel.City
                    });

                return RedirectToAction("Index");
            }
            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult RemovePerson(int personId)
        {
            Person.RemovePerson(personId);
            return RedirectToAction("Index");
        }
    }
}