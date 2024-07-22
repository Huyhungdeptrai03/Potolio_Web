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
    public class CategoriesController : Controller
    {
        

        public CategoriesController()
        {
            
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            List<Categories> CategoriesList = new List<Categories>();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Categories"))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    CategoriesList = JsonConvert.DeserializeObject<List<Categories>>(apiRepose);
                }
            }
            return View(CategoriesList);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories categories = new Categories();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Categories/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<Categories>(apiRepose);
                }
            }
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

       //create
       public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Categories,Name")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json");
                    using (var reponse = await http.PostAsync("https://localhost:44369/api/Categories", content))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<Categories>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Categories categories = new Categories();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Categories/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<Categories>(apiRepose);
                }
            }
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Categories,Name")] Categories categories)
        {
            if (id != categories.Id_Categories)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var http = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(categories), Encoding.UTF8, "application/json");
                    using (var reponse = await http.PutAsync("https://localhost:44369/api/Categories/" + id, content))
                    {
                        string apiRepose = await reponse.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<Categories>(apiRepose);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categories categories = new Categories();
            using (var http = new HttpClient())
            {
                using (var reponse = await http.GetAsync("https://localhost:44369/api/Categories/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<Categories>(apiRepose);
                }
            }
            if (categories == null)
            {
                return NotFound();
            }

            return View(categories);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var http = new HttpClient())
            {
                using (var reponse = await http.DeleteAsync("https://localhost:44369/api/Categories/" + id))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriesExists(int id)
        {
            return true;
        }
    }
}
