using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPP.Helper;
using WebAPP.Models;

namespace WebAPP.Controllers
{
    public class TimeScheduleController : Controller
    {
        Helper_API _api = new Helper_API();
        // GET: TimeScheduleController
        public async Task<ActionResult> IndexAsync()
        {
            List<TimeSchedule> timeshedules = new List<TimeSchedule>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/TimeSchedules");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                timeshedules = JsonConvert.DeserializeObject<List<TimeSchedule>>(result);
            }
            return View(timeshedules);
        }

        // GET: TimeScheduleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeScheduleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeScheduleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeScheduleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeScheduleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeScheduleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeScheduleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}
