using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.HttpServices
{
    public class PersonelURLs
    {
        protected const string BaseUrl = "https://localhost:44368/api/personel/";
        protected const string GetPersonelByIdUrl = "GetPersonelById";
        protected const string GetPersonelListesiUrl = "PersonelListesi";
        protected const string PersonelEkleUrl = "PersonelEkle";
        protected const string PersonelWithDepartmanUrl = "";
        protected const string PersonelGuncelleUrl = "PersonelGuncelle";
        protected const string PersonelSilUrl = "PersonelSil";
    }
}
