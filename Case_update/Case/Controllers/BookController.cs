using CaseDataAccess.Repository.IRepository;
using CaseModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace Case.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
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
            BookVM bookVM = new()
            {
                Book = new(),
                AuthorList = _unitOfWork.Author.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(bookVM);
            }

            else
            {
                bookVM.Book = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == id);
                return View(bookVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM bookVM)
        {
            if (ModelState.IsValid)
            {
                if (bookVM.Book.Id == 0)
                {
                    _unitOfWork.Book.Add(bookVM.Book);
                }
                else
                {
                    _unitOfWork.Book.Update(bookVM.Book);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                bookVM.AuthorList = _unitOfWork.Author.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(bookVM);
            }
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _unitOfWork.Book.GetAll(includeProperties: "Author");
            return Json(new { data = bookList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Hata" });
            }
            _unitOfWork.Book.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Silindi" });
        }
        #endregion
    }
}