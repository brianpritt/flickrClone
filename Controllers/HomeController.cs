using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using FlickrClone.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace FlickrClone.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        [HttpPost]
        public IActionResult Create(IFormFile picture, string name, string description)
        {
            byte[] newPicture = new byte[0];
            if (picture != null)
            {
                using (Stream fileStream = picture.OpenReadStream())
                using (MemoryStream ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    newPicture = ms.ToArray();
                }
            }
            Photo newPhoto = new Photo(name, description, newPicture);
            db.Photos.Add(newPhoto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
