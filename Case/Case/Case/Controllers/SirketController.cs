using CaseDataAccess.Repository.IRepository;
using CaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Case.Controllers
{
    public class SirketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SirketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Sirket> objSirketList = _unitOfWork.Sirket.GetAll();
            return View(objSirketList);
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sirket obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Sirket.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Şirket Başarıyla Eklendi";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var sirketFromDbFirst = _unitOfWork.Sirket.GetFirstOrDefault(u => u.Id == id);

            if (sirketFromDbFirst == null)
            {
                return NotFound();
            }

            return View(sirketFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sirket obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Sirket.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Güncelleme Başarılı";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var sirketFromDbFirst = _unitOfWork.Sirket.GetFirstOrDefault(u => u.Id == id);

            if (sirketFromDbFirst == null)
            {
                return NotFound();
            }

            return View(sirketFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Sirket.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Sirket.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Silme işlemi gerçekleşti.";
            return RedirectToAction("Index");
        }
    }
}