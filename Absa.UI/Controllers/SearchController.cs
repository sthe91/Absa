using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Absa.Infrastructure.Models;
using Absa.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Absa.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly HttpClient _httpClient;

        public SearchController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AbsaApi");
        }

        public async Task<IActionResult> Index(string searchText)
        {
            var entries = await SearchEntriesAsync(searchText);

            var vm = new ContactListViewModel()
            {
                Entries = entries
            };

            return View(vm);
        }

        private async Task<List<Entry>> SearchEntriesAsync(string searchText)
        {
            var responseMessage = await _httpClient.GetAsync($"Entry/Search/{searchText}");

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = responseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<Entry>>(content.Result);
            }

            return new List<Entry>();
        }
    }
}