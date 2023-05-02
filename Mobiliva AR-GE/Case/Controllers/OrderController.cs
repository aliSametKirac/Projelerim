using CaseDataAccess.Repository.IRepository;
using CaseModels.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace Case.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Order> objOrderList = _unitOfWork.Order.GetAll();
            return View(objOrderList);
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Order.Add(obj);
                _unitOfWork.Save();
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

            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);

            if (orderFromDbFirst == null)
            {
                return NotFound();
            }

            return View(orderFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Order.Update(obj);
                _unitOfWork.Save();
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

            var orderFromDbFirst = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);

            if (orderFromDbFirst == null)
            {
                return NotFound();
            }

            return View(orderFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Order.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Order.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}