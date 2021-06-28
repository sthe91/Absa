using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Absa.UI.ViewModels;
using Absa.Infrastructure.Models;

namespace Absa.UI.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly HttpClient _httpClient;

        public PhonebookController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AbsaApi");
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("Phonebook/GetAll");

            var content = responseMessage.Content.ReadAsStringAsync();

            var vm = new PhonebookListViewModel()
            {
                Phonebooks = JsonConvert.DeserializeObject<List<Phonebook>>(content.Result)
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            return View(new PhonebookViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhonebookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var content = new StringContent(JsonConvert.SerializeObject(vm.Phonebook), Encoding.UTF8, "application/json");

            var responseMessage = await _httpClient.PostAsync("Phonebook/Create", content);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                vm.HasError = true;
            }

            vm.ShowAlerts = true;

            return View(vm);
        }
    }
}