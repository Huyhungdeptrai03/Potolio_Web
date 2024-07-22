using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppApi.Model;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Controllers
{
    public class AboutsController : Controller
    {
       

        public AboutsController()
        {

        }

        // GET: Abouts
        public async Task<IActionResult> Index()
        {
            List<About> AboutList = new List<About>();
            using (var http = new HttpClient())
            {
                try
                {
                    // Tải dữ liệu byte từ API
                    byte[] imageArray = await http.GetByteArrayAsync("https://localhost:44340/api/AboutImage");

                    // Chuyển đổi byte sang chuỗi base64
                    string base64Image = Convert.ToBase64String(imageArray);
                    ViewBag.ImageData = base64Image;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    ViewBag.ImageData = null;
                }
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Abouts"))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    AboutList = JsonConvert.DeserializeObject<List<About>>(apiRepose);
                }
            }
            return View(AboutList);
        }

        // GET: Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            About about = new About();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Abouts/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    about = JsonConvert.DeserializeObject<About>(apiRepose);
                }
            }
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        //// GET: Abouts/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id_About,About_Image")] About about)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(about);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(about);
        //}

        // GET: Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            About about = new About();
            using (var http = new HttpClient()) {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Abouts/" + id)) {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    about = JsonConvert.DeserializeObject<About>(apiRepose);
                }
            }
            if (about == null) {
                return NotFound();
            }
            return View(about);

        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_About,About_Image")] About about)
        {
            if (id != about.Id_About)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(about), Encoding.UTF8, "application/json");
                    using (var reponse = await http.PutAsync("https://localhost:44369/api/Abouts/" + id, content))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        about = JsonConvert.DeserializeObject<About>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (ModelState.IsValid) {
                return NotFound();
            }
            About about = new About();
            using (var http = new HttpClient()) {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Abouts/" + id)) {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    about = JsonConvert.DeserializeObject<About>(apiRepose);
                }
            }
            if (about == null) {
                return NotFound();
            }
            return View(about);
        }

        // POST: Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid) {
                return NotFound();
            }
            About about = new About();
            using (var http = new HttpClient()) {
                using (var reponse = await http.DeleteAsync("https://localhost:44369/api/Abouts/" + id)) {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    about = JsonConvert.DeserializeObject<About>(apiRepose);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
            return false;
        }
    }
}
