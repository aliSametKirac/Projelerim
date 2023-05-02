using CaseDataAccess.Repository.IRepository;
using CaseModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Case.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
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
            OrderDetailVM orderDetailVM = new()
            {
                OrderDetail = new(),
                OrderList = _unitOfWork.Order.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CustomerName,
                    Value = i.Id.ToString()
                }),
                ProductList = _unitOfWork.Product.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Description,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(orderDetailVM);
            }

            else
            {
                orderDetailVM.OrderDetail = _unitOfWork.OrderDetail.GetFirstOrDefault(u => u.Id == id);
                return View(orderDetailVM);
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OrderDetailVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.OrderDetail.Id == 0)
                {
                    _unitOfWork.OrderDetail.Add(obj.OrderDetail);
                }
                else
                {
                    _unitOfWork.OrderDetail.Update(obj.OrderDetail);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetailList = _unitOfWork.OrderDetail.GetAll(includeProperties: "Order,Product");
            return Json(new { data = orderDetailList });

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.OrderDetail.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false });
            }
            _unitOfWork.OrderDetail.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true });
        }
        #endregion
    }
}