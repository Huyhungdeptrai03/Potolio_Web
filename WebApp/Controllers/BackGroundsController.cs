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
    public class BackGroundsController : Controller
    {
        

        public BackGroundsController()
        {
            
        }

        // GET: BackGrounds
        public async Task<IActionResult> Index()
        {
            List<BackGround> BackGroundList = new List<BackGround>();
            using (var http = new HttpClient())
            {
                try
                {
                    // Tải dữ liệu byte từ API
                    byte[] imageArray = await http.GetByteArrayAsync("https://localhost:44369/api/BackGrounds");

                    // Chuyển đổi byte sang chuỗi base64
                    string base64Image = Convert.ToBase64String(imageArray);
                    ViewBag.ImageData = base64Image;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    ViewBag.ImageData = null;
                }
                using (var reponse = await http.GetAsync("https://localhost:44369/api/BackGrounds"))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    BackGroundList = JsonConvert.DeserializeObject<List<BackGround>>(apiRepose);
                }
            }
            return View(BackGroundList);
        }

        // GET: BackGrounds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BackGround backGround = new BackGround();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/BackGrounds/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    backGround = JsonConvert.DeserializeObject<BackGround>(apiRepose);
                }
            }
            if (backGround == null)
            {
                return NotFound();
            }

            return View(backGround);
        }

        // GET: BackGrounds/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BackGrounds/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id_BackGroud,BackGround_Image")] BackGround backGround)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var http = new HttpClient())
        //        {
        //            var json = JsonConvert.SerializeObject(backGround);
        //            var data = new StringContent(json, Encoding.UTF8, "application/json");

        //            using (var reponse = await http.PostAsync("https://localhost:44369/api/BackGrounds", data))
        //            {
        //                string apiRepose = await reponse.Content.ReadAsStringAsync();
        //                backGround = JsonConvert.DeserializeObject<BackGround>(apiRepose);
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }

        //}

        // GET: BackGrounds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BackGround backGround = new BackGround();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/BackGrounds/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    backGround = JsonConvert.DeserializeObject<BackGround>(apiRepose);
                }
            }
            if (backGround == null)
            {
                return NotFound();
            }
            return View(backGround);
        }

        // POST: BackGrounds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_BackGroud,BackGround_Image")] BackGround backGround)
        {
            if (id != backGround.Id_BackGroud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(backGround);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    using (var reponse = await http.PutAsync("https://localhost:44369/api/BackGrounds/" + id, data))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        backGround = JsonConvert.DeserializeObject<BackGround>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(backGround);
        }

        // GET: BackGrounds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BackGround backGround = new BackGround();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/BackGrounds/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    backGround = JsonConvert.DeserializeObject<BackGround>(apiRepose);
                }
            }
            if (backGround == null)
            {
                return NotFound();
            }

            return View(backGround);
        }

        // POST: BackGrounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var http = new HttpClient())
            {
                using (var reponse = await http.DeleteAsync("https://localhost:44369/api/BackGrounds/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BackGroundExists(int id)
        {
            return true;
        }
    }
}
