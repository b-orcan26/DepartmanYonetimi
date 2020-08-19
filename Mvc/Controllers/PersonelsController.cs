using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Mvc.HttpServices;


namespace Mvc.Controllers
{
    [Route("{controller}/{action}")]
    public class PersonelsController : Controller
    {
        PersonelClientService persService;
        DepartmanClientService depService;

        public PersonelsController()
        {
            persService = new PersonelClientService();
            depService = new DepartmanClientService();
        }

        [HttpGet]   // ALL PERSONEL
        public async Task<IActionResult> Personeller()
        {
            return View(await persService.getPersonels());
        }


        [HttpGet]  // ADD PERSONEL
        public async Task<IActionResult> PersonelEkle()
        {

            ViewBag.Departmanlar = new SelectList(await depService.getDepartmans(), "id", "ad");
            return View();
        }


        [HttpPost]  // ADD PERSONEL [ post ]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelEkle(Personel p)
        {
            if (ModelState.IsValid)
            {
                await persService.PersonelEkle(p);
            }

            return RedirectToAction("Personeller");
        }


        [HttpGet]
        public async Task<RedirectToActionResult> PersonelSil(int id)
        {
            await persService.PersonelSil(id);
            return RedirectToAction("Personeller");
        }

        [HttpGet]
        public async Task<IActionResult> PersonelGuncelle(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var personel = await persService.PersonelById(id);

            if (personel == null)
            {
                return NotFound();
            }
            var departmanList = await depService.getDepartmans();

            ViewBag.Departmanlar = new SelectList(departmanList, "id", "ad");
            return View(personel);
        }


        [HttpPost]
        public async Task<RedirectToActionResult> PersonelGuncelle([FromForm] Personel p)
        {
            if (ModelState.IsValid)
            {
                await persService.PersonelGuncelle(p);

            }
            
            return RedirectToAction("Personeller");
        }





    }
}
