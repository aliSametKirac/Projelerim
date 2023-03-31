using CaseDataAccess.Repository.IRepository;
using CaseModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Case.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public KullaniciController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            KullaniciVM kullaniciVM = new()
            {
                Kullanici = new(),
                SirketList = _unitOfWork.Sirket.GetAll().Select(i => new SelectListItem
                {
                    Text = i.SirketAdi,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(kullaniciVM);
            }

            else
            {
                kullaniciVM.Kullanici = _unitOfWork.Kullanici.GetFirstOrDefault(u => u.Id == id);
                return View(kullaniciVM);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(KullaniciVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Kullanici.Id == 0)
                {
                    _unitOfWork.Kullanici.Add(obj.Kullanici);
                }
                else
                {
                    _unitOfWork.Kullanici.Update(obj.Kullanici);
                }     
                _unitOfWork.Save();
                TempData["success"] = "Kullanıcı başarıyla oluşturuldu.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var kullaniciList = _unitOfWork.Kullanici.GetAll(includeProperties: "Sirket");
            return Json(new { data = kullaniciList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Kullanici.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Kullanıcı Bulunamadı." });
            }
            _unitOfWork.Kullanici.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Kullanıcı Silindi." });
        }
        #endregion
    }
}