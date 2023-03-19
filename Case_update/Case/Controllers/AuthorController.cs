using CaseDataAccess.Repository.IRepository;
using CaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Case.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Author> objAurhorList = _unitOfWork.Author.GetAll();
            return View(objAurhorList);
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author obj)
        {
            if (obj.Name == obj.About)
            {
                ModelState.AddModelError("About", "İsim ve Özgeçmiş farklı değerler olmalıdır.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Yazar Başarıyla Eklendi";
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

            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);

            if (authorFromDbFirst == null)
            {
                return NotFound();
            }

            return View(authorFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author obj)
        {
            if (obj.Name == obj.About)
            {
                ModelState.AddModelError("name", "İsim ve Özgeçmiş farklı değerler olmalıdır.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Author.Update(obj);
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

            var authorFromDbFirst = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);

            if (authorFromDbFirst == null)
            {
                return NotFound();
            }

            return View(authorFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Author.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Silme işlemi gerçekleşti.";
            return RedirectToAction("Index");

        }
    }
}