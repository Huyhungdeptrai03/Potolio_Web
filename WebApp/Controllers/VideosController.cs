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
    public class VideosController : Controller
    {
        

        public VideosController()
        {
           
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            List<Video> VideoList = new List<Video>();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Videos"))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    VideoList = JsonConvert.DeserializeObject<List<Video>>(apiRepose);
                }
            }
            return View(VideoList);
        }

        //details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Video video = new Video();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Videos/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    video = JsonConvert.DeserializeObject<Video>(apiRepose);
                }
            }
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        //create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Url,Description")] Video video)
        {
            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(video), Encoding.UTF8, "application/json");
                    using (var reponse = await http.PostAsync("https://localhost:44369/api/Videos", content))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        video = JsonConvert.DeserializeObject<Video>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }




        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Video video = new Video();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Videos/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    video = JsonConvert.DeserializeObject<Video>(apiRepose);
                }
            }
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url,Description")] Video video)
        {
            if (id != video.Id_Video)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(video), Encoding.UTF8, "application/json");
                    using (var reponse = await http.PutAsync("https://localhost:44369/api/Videos/" + id, content))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        video = JsonConvert.DeserializeObject<Video>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(video);
        }

      //delete
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Delete(int id)
        {
            using (var http = new HttpClient())
            {
                using (var reponse = await http.DeleteAsync("https://localhost:44369/api/Videos/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }


        private bool VideoExists(int id)
        {
            bool exist = false;
            using (var http = new HttpClient())
            {
                using (var reponse = http.GetAsync("https://localhost:44369/api/Videos/" + id).Result)
                {
                    string apiRepose = reponse.Content.ReadAsStringAsync().Result;
                    if (apiRepose != null)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }






        
    }
}
