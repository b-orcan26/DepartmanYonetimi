using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private IPersonelService personelManager;

        public PersonelController(IPersonelService _personelManager)
        {
            personelManager = _personelManager;

        }
        
        [HttpGet]
        public List<Personel> PersonelListesi()
        {
            return personelManager.AllData();
        }

        [HttpPost]
        public bool PersonelEkle(Personel p)
        {
            return personelManager.AddData(p);
        }

        [HttpGet]
        public String PersonelWithDepartman()
        {
            //belli alanları listeye dahil edip döndürüyoruz bu işlemi dataAccessLayer veya Business'a taşımalı
            var liste = (from i in personelManager.PersonelsWithDepatman() 
                         select new { id=i.id ,ad=i.ad ,soyad=i.soyad ,departmanID=i.Departman.id, departmanAd = i.Departman.ad }).ToList();
            return JsonConvert.SerializeObject(liste);
        }


        [HttpGet("{id}")]
        public IActionResult GetPersonelById(int id)
        {
            var data = personelManager.GetDataById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult PersonelGuncelle(Personel p)
        {
            if(p.id == 0)
            {
                return BadRequest("id alani bos gecilemez");
            }
            personelManager.UpdateData(p);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void PersonelSil(int id)
        {
            personelManager.DeleteData(id);
        }

    }
}
