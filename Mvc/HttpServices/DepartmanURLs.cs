using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.HttpServices
{
    public class DepartmanURLs
    {
        protected const string BaseUrl = "https://localhost:44368/api/Departman/";
        protected const string GetDepartmanByIdUrl = "DepartmanById";
        protected const string GetDepartmanListesiUrl = "DepartmanListesi";
        protected const string DepartmanEkleUrl = "DepartmanEkle";
        protected const string DepartmanWithPersonelUrl = "DepartmanWithPersonels";
        protected const string DepartmanGuncelleUrl = "DepartmanGuncelle";
        protected const string DepartmanSilUrl = "DepartmanSil";
    }
}
