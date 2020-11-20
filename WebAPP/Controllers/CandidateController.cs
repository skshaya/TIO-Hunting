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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CandidateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CandidateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CandidateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
