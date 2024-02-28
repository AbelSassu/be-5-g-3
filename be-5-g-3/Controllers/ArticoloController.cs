using Microsoft.AspNetCore.Mvc;
using be_5_g_3.Models;

namespace be_5_g_3.Controllers
{
    public class ArticoloController : Controller
    {
        public IActionResult Index()
        {
            return View(Db.GetAll());
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (id.HasValue)
            {
                var art = Db.GetById(id);
                if (art is null)
                {
                    return View("Error");
                }
                return View(art);
            }
            else {
                return RedirectToAction("Index", "Articolo");
            }

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(string name, string descrizione, double price, string imgCover, string img1, string img2)
        {
            Articolo articolo = new Articolo();
            articolo.Name = name;
            articolo.Description = descrizione;
            articolo.Price = price;
            articolo.ImgCover = imgCover;
            articolo.ImgDetails[0] = img1;
            articolo.ImgDetails[1] = img2;
            Db.Add(articolo);

            return RedirectToAction("Details", new {id = articolo.Id});      }
    }
}
