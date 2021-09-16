using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Human> HumanList = new List<Human>
        {
            new Human{ Id = 0, FirstName = "Alexander", Patronymic = "Valerevich", LastName = "Dolgosheev", Age = 33 },
            new Human{ Id = 1, FirstName = "Marina", Patronymic = "Vladimirovna", LastName = "Dolgosheeva", Age = 32 },
            new Human{ Id = 2, FirstName = "Alica", Patronymic = "Alexandrovna", LastName = "Dolgosheeva", Age = 7 },
        };

        public IActionResult Index() // http://[url]:5000/Home/Index
        {
            return View();
        }

        public IActionResult SecondAction(string message)
        {
            return Content($"Hello from controller [HomeController] : message => {message}!");
        }

        public IActionResult Humans()
        {
            return View(HumanList);
        }
    }
}
