using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Sebrae.Web.Models;
using RestSharp;

namespace Sebrae.Web.Controllers
{
    public class ContaController : Controller
    {
      

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7238");
            var model = await httpClient.GetFromJsonAsync<ContaModel[]>("/api/conta/");
                        
            return View(model);
        }



        public ViewResult GetConta() => View();

        [HttpPost]
        public async Task<IActionResult> GetReserva(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7238");
            var model = await httpClient.GetFromJsonAsync<ContaModel>("/api/conta/" + id);

            return View(model);

        }


        public ViewResult AddConta() => View();

        [HttpPost]
        public async Task<IActionResult> AddConta(ContaModel conta)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7238");
                using var response1 = await httpClient.PostAsJsonAsync("/api/conta/", conta);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateConta(int id)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7238");
            var model = await httpClient.GetFromJsonAsync<ContaModel>("/api/conta/" + id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConta(ContaModel conta)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7238");
                using var response1 = await httpClient.PutAsJsonAsync("/api/conta/", conta);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConta(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://localhost:7238");
                using var response1 = await httpClient.DeleteAsync("/api/conta/"+ id);
                response1.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
