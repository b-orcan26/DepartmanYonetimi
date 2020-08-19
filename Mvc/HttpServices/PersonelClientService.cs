using Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.HttpServices
{
    public class PersonelClientService : PersonelURLs
    {
        HttpClient httpClient;

        public PersonelClientService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Personel>> getPersonels()   // HTTP GET  ~ all personel
        {
            var response = await httpClient.GetAsync(BaseUrl+ GetPersonelListesiUrl);
            string apiResponse = await response.Content.ReadAsStringAsync();                  
            return JsonConvert.DeserializeObject<List<Personel>>(apiResponse); 
        }

        public async Task<bool> PersonelEkle(Personel p)    // HTTP POST ~ add personel
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUrl + PersonelEkleUrl, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            bool isAdded = Boolean.Parse(apiResponse);
            return isAdded;
        }

        public async Task<string> PersonelSil(int id) // HTTP DELETE ~ delete personel
        {
          
            var response = await httpClient.DeleteAsync((BaseUrl + PersonelSilUrl+"/"+id));
            string apiResponse = await response.Content.ReadAsStringAsync();
            
            return apiResponse;
        }

        public async Task<bool> PersonelGuncelle(Personel p) // HTTP POST ~ update personel
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUrl + PersonelGuncelleUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Personel> PersonelById(int id)
        {
            var response = await httpClient.GetAsync(BaseUrl + GetPersonelByIdUrl+"/"+id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Personel>(apiResponse);
        }

    }
}
