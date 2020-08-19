using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.HttpServices;

namespace Mvc.Controllers
{
    [Route("{controller}/{action}")]
    public class DepartmansController : Controller
    {

        DepartmanClientService depService;

        public DepartmansController()
        {
            depService = new DepartmanClientService();
        }

        [HttpGet]   // ALL DEPARTMAN
        public async Task<IActionResult> Departmanlar()
        {
            return View(await depService.getDepartmans());
        }


        [HttpGet]  // ADD DEPARTMAN
        public IActionResult DepartmanEkle()
        {
            return View();
        }


        [HttpPost]  
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepartmanEkle(Departman d)
        {
            if (ModelState.IsValid)
            {
                await depService.DepartmanEkle(d);
            }

            return RedirectToAction("Departmanlar");
        }


        [HttpGet]
        public async Task<RedirectToActionResult> DepartmanSil(int id)
        {
            await depService.DepartmanSil(id);
            return RedirectToAction("Departmanlar");
        }

        [HttpGet]
        public async Task<IActionResult> DepartmanGuncelle(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var departman = await depService.DepartmanById(id);

            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }


        [HttpPost]
        public async Task<RedirectToActionResult> DepartmanGuncelle([FromForm] Departman d)
        {
            if (ModelState.IsValid)
            {
                await depService.DepartmanGuncelle(d);

            }

            return RedirectToAction("Departmanlar");
        }

        [HttpGet]
        public async Task<IActionResult> DepartmanWithPersonels()
        {
            var list = await depService.DepartmanWithPersonels();
            return View(list);
        }



    }
}
