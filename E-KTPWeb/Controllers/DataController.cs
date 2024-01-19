using E_KTPWeb.Data;
using E_KTPWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_KTPWeb.Controllers
{
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public DataController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int page = 1, string search = "", string category = "")
        {
            int pageSize = 5;

            var query = _db.DataKTP.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = category switch
                {
                    "nik" => query.Where(d => d.NIK.ToString().Contains(search)),
                    "name" => query.Where(d => d.Name.Contains(search)),
                    _ => query
                };
            }

            var totalRecords = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new PaginationModel<DataKTP>
            {
                Data = data,
                CurrentPage = page,
                TotalPages = totalPages
            };

            ViewBag.CurrentFilter = search;
            ViewBag.CurrentCategory = category;

            // Menambahkan logika pengecekan apakah hasil pencarian kosong
            if (totalRecords == 0)
            {
                ViewBag.SearchError = "Maaf, data yang Anda cari tidak ditemukan.";
            }

            return View(model);
        }




        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(DataKTP obj)
        {
           
            if (ModelState.IsValid)
            {
                _db.DataKTP.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

         [HttpPost]
        public IActionResult Edit(DataKTP obj)
        {
            if (ModelState.IsValid)
            {
                _db.DataKTP.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id== null || id == 0)
            { 
                return NotFound();
            }
            DataKTP? dataKTPfromDb = _db.DataKTP.Find(id);
            //DataKTP? dataKTPfromDb1 = _db.DataKTP.FirstOrDefault(u=>u.Id==id);
            //DataKTP? dataKTPfromDb2 = _db.DataKTP.Where(u => u.Id == id).FirstOrDefault();

            if (dataKTPfromDb == null)
            {
                return NotFound();
            }
            return View(dataKTPfromDb);
        }

        [HttpPost, ActionName("Hapus")]
        public IActionResult HapusPOST(int? id)
        {
            DataKTP? obj = _db.DataKTP.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.DataKTP.Remove(obj);
            _db.SaveChanges();

            // Reset nilai ID jika diperlukan
            ResetAutoIncrement();

            return RedirectToAction("Index");
        }

        public IActionResult Hapus(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DataKTP? dataKTPfromDb = _db.DataKTP.Find(id);

            if (dataKTPfromDb == null)
            {
                return NotFound();
            }
            return View(dataKTPfromDb);
        }

        private void ResetAutoIncrement()
        {
            // Dapatkan nilai ID tertinggi yang ada dalam tabel
            int maxId = _db.DataKTP.Max(d => (int?)d.Id) ?? 0;

            // Atur ulang nilai auto-increment
            _db.Database.ExecuteSqlRaw($"DBCC CHECKIDENT('DataKTP', RESEED, {maxId})");
        }


        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            DataKTP? dataKTPfromDb = _db.DataKTP.Find(id);
           
            if (dataKTPfromDb == null)
            {
                return NotFound();
            }
            return View(dataKTPfromDb);
        }



    }
}
