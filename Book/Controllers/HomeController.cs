using Book.Models;
using Book.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookDb bookDb;
        private readonly IWebHostEnvironment webHost;

        public HomeController(IBookDb bookDb,IWebHostEnvironment webHost)
        {
            this.bookDb = bookDb;
            this.webHost = webHost;
        }
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Kitoblar()
        {
            var kitoblar = bookDb.GetAll();
            HomeKitoblarViewModel viewModel = new HomeKitoblarViewModel()
            {
                Books = kitoblar
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Yaratish() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Yaratish(HomeYaratishViewModel yaratishViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = string.Empty;
                if (yaratishViewModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(webHost.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + yaratishViewModel.Photo.FileName;
                    string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                    yaratishViewModel.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                }

                Books books = new Books
                {
                    Title = yaratishViewModel.Title,
                    Author = yaratishViewModel.Author,
                    PublishedYear = yaratishViewModel.PublishedYear,
                    Photo = uniqueFileName
                };

                var newBook = bookDb.Create(books);
                return RedirectToAction("kitoblar");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Ochirish() //bu sahifani ochish uchun
        {
            var kitoblar = bookDb.GetAll();
            HomeKitoblarViewModel viewModel = new HomeKitoblarViewModel()
            {
                Books = kitoblar
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id) //bu kitobni o'chirish uchun
        {
            bookDb.Delete(id);
            return RedirectToAction("ochirish");
        }

        


    }
}
