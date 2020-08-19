using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.HttpServices
{
    public class DepartmanClientService : DepartmanURLs
    {
        HttpClient httpClient;

        public DepartmanClientService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Departman>> getDepartmans()   // HTTP GET  ~ all departman
        {
            var response = await httpClient.GetAsync(BaseUrl + GetDepartmanListesiUrl);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Departman>>(apiResponse);
        }

        public async Task<bool> DepartmanEkle(Departman d)    // HTTP POST ~ add departman
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUrl + DepartmanEkleUrl, content);
            string apiResponse = await response.Content.ReadAsStringAsync();
            bool isAdded = Boolean.Parse(apiResponse);
            return isAdded;
        }

        public async Task<string> DepartmanSil(int id) // HTTP DELETE ~ delete departman
        {

            var response = await httpClient.DeleteAsync((BaseUrl + DepartmanSilUrl + "/" + id));
            string apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        public async Task<bool> DepartmanGuncelle(Departman d) // HTTP POST ~ update personel
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(d), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(BaseUrl + DepartmanGuncelleUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<Departman> DepartmanById(int id)
        {
            var response = await httpClient.GetAsync(BaseUrl + GetDepartmanByIdUrl + "/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Departman>(apiResponse);
        }

        public async Task<List<Departman>> DepartmanWithPersonels()
        {
            var response = await httpClient.GetAsync(BaseUrl + DepartmanWithPersonelUrl);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Departman>>(apiResponse);
        }


    }
}
