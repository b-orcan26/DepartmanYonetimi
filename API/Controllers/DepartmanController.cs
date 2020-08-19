using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmanController : ControllerBase
    {
        private IDepartmanService departmanManager;

        //IActionResult neden kullanılmalı örneğin database'de olmayan bir id DepartmanById() metoduna gecilseydi biz buna 404 donmeliydik
        //status code donebilmek icin IActionResult geri dönüs tipini kullanmalıyız.

        public DepartmanController(IDepartmanService _departmanManager)
        {
            departmanManager = _departmanManager;

        }

        [HttpPost]
        public bool DepartmanEkle([FromBody] Departman d)
        {
            return departmanManager.AddData(d);
        }


        [HttpGet]
        public List<Departman> DepartmanListesi()
        {
            return departmanManager.AllData();
        }

        [HttpGet("{id}")]
        public Departman DepartmanById(int id)
        {
            return departmanManager.GetDataById(id);
        }

        [HttpPost]
        public void DepartmanGuncelle(Departman d)
        {
            departmanManager.UpdateData(d);
        }

        [HttpDelete("{id}")]
        public void DepartmanSil(int id)
        {
            departmanManager.DeleteData(id);
        }

        [HttpGet]
        public IActionResult DepartmanWithPersonels()
        {
            var list = departmanManager.DepartmanWithPersonels();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
