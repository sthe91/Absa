using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Absa.Infrastructure.Models;
using Absa.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Absa.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AbsaApi");
        }

        public async Task<IActionResult> Index(string pid)
        {
            var entries = await GetEntriesAsync(pid);

            var vm = new ContactListViewModel(pid)
            {
                Entries = entries
            };

            return View(vm);
        }

        public IActionResult Create(string pid)
        {
            var phonebook = new Phonebook() { PhonebookId = new Guid(pid) };

            var vm = new ContactViewModel(phonebook);
            vm.Entry.Phonebook.PhonebookId = new Guid(pid);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var content = new StringContent(JsonConvert.SerializeObject(vm.Entry), Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("Entry/Create", content);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                vm.HasError = true;
            }

            vm.ShowAlerts = true;

            return View(vm);
        }

        private async Task<List<Entry>> GetEntriesAsync(string phonebookId)
        {
            var responseMessage = await _httpClient.GetAsync($"Entry/GetEntriesByPhonebookId/{phonebookId}");

            var content = responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Entry>>(content.Result);
        }

        private async Task<Phonebook> GetPhonebookByIdAsync(string phonebookId)
        {
            var responseMessage = await _httpClient.GetAsync($"Phonebook/GetById/{phonebookId}");

            var content = responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Phonebook>(content.Result);
        }
    }
}