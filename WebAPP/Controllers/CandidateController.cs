using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPP.Helper;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class CandidateController : Controller
    {
        Helper_API _api = new Helper_API();
        // GET: CandidateController
        public async Task<IActionResult> Index()
        {
            List<Candidate> candidates = new List<Candidate>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/candidates");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                candidates = JsonConvert.DeserializeObject<List<Candidate>>(result);
            }

            return View(candidates);
        }

        // GET: CandidateController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            Candidate candidate = new Candidate();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/candidates/" + id);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                candidate = JsonConvert.DeserializeObject<Candidate>(result);
            }
            return View(candidate);
        }

        // GET: CandidateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CandidateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Candidate candidate)
        {
            try
            {
                DateTime nowTime = DateTime.Now;
                Random gen = new Random();
                int range = (60 * 9) - 30; //min range
                DateTime? scheduledStartTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 8, 0, 0, 0);
                candidate.StartDate = scheduledStartTime.Value.AddMinutes(gen.Next(range));
                candidate.EndDate = candidate.StartDate.Value.AddMinutes(30);

                var content = new StringContent(JsonConvert.SerializeObject(candidate), Encoding.UTF8, "application/json");
                HttpClient httpClient = _api.Initial();
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("api/candidates", content);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            Candidate candidate = new Candidate();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/candidates/" + id);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                candidate = JsonConvert.DeserializeObject<Candidate>(result);
            }
            return View(candidate);
        }

        // POST: CandidateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Candidate candidate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(candidate), Encoding.UTF8, "application/json");
                    HttpClient httpClient = _api.Initial();
                    HttpResponseMessage httpResponseMessage = await httpClient.PutAsync("api/candidates/" + id, content);
                    return RedirectToAction(nameof(Index));
                }
                return View(candidate);
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Candidate candidate = new Candidate();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/candidates/" + id);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                candidate = JsonConvert.DeserializeObject<Candidate>(result);
            }
            return View(candidate);
        }

        // POST: CandidateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Candidate candidate)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(candidate), Encoding.UTF8, "application/json");
                HttpClient httpClient = _api.Initial();
                HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync("api/candidates/" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
