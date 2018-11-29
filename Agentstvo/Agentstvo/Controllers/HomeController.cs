using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agentstvo.DAO;
using Agentstvo.Models;

namespace TP.Controllers
{
    public class HomeController : Controller
    {
        GroupDogDAO groupDAO = new GroupDogDAO();
        DogovorDAO dogovorDAO = new DogovorDAO();

        /*     protected bool ValidateDogovor(Dogovor DogovorToValidate)
               {
                   if (DogovorToValidate.IDKl == null)
                       ModelState.AddModelError("FIO", "Поле 'Фамилия, Имя, Отчество ' обязательно для заполнения.");
                   if (DogovorToValidate.IDAg == null)
                       ModelState.AddModelError("Avtor", "Поле 'Автор книги' обязательно для заполнения.");
                   if (DogovorToValidate.B == null)
                       ModelState.AddModelError("Book", "Поле 'Название книги' обязательно для заполнения.");
                   if (DogovorToValidate.Librarian == null)
                       ModelState.AddModelError("Librarian", "Поле 'Библиотекарь' обязательно для заполнения.");
                   if (DogovorToValidate.Date == null)
                       ModelState.AddModelError("Date", "Поле 'Дата' обязательно для заполнения.");
                   return ModelState.IsValid;
               }
               */

        public ActionResult Index(int? id)
        {
            ViewData["Groups"] = groupDAO.GetAllGroups();
            var dogovor = id == null ? dogovorDAO.GetAllDogovor() : dogovorDAO.GetAllDogovor().Where(x => x.GroupDog.Id == id);
            if (!Request.IsAjaxRequest())
                // Normal Request
                return View(dogovor);
            else
                // Ajax Request
                return PartialView("DogovorList", dogovor);

        }


        StrSluDAO strslDAO = new StrSluDAO();

        public ActionResult IndexStr()
        {
            return View(strslDAO.GetAllStrSl());

        }


        public ActionResult DetailsDogov(int id)
        {
            return View(dogovorDAO.getDogovor(id));
        }
        protected bool ViewDataSelectList(int GroupId)
        {
            var groups = groupDAO.GetAllGroups();
            ViewData["GroupId"] = new SelectList(groups, "Id", "Name", GroupId);
            return groups.Count() > 0;
        }

        public ActionResult CreateDogov()
        {
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("CreateDogov");
        }

        [HttpPost]
        public ActionResult CreateDogov(int GroupId, [Bind(Exclude = "Id")] Dogovor Dogov)
        {
            ViewDataSelectList(GroupId);


            try
            {
                if (dogovorDAO.addDogovor(GroupId, Dogov))
                    return RedirectToAction("Index");
                else
                    return View(Dogov);
            }
            catch
            {
                return View(Dogov);
            }

        }

        public ActionResult EditDogov(int id)
        {
            Dogovor Dogov = dogovorDAO.getDogovor(id);
            if (!ViewDataSelectList(Dogov.GroupDog.Id))
                return RedirectToAction("Index");
            return View(dogovorDAO.getDogovor(id));
        }

        [HttpPost]
        public ActionResult EditDogov(int GroupId, Dogovor Dogov)
        {
            ViewDataSelectList(-1);
            try
            {
                if (ModelState.IsValid && dogovorDAO.updateDogovor(GroupId, Dogov))
                    return RedirectToAction("Index");
                else
                    return View(Dogov);
            }
            catch
            {
                return View(Dogov);
            }
        }

        public ActionResult DeleteDogov(int id)
        {
            return View(dogovorDAO.getDogovor(id));
        }

        [HttpPost]
        public ActionResult DeleteDogov(int id, Dogovor Dogov)
        {
            try
            {
                if (dogovorDAO.deleteDogovor(id))
                    return RedirectToAction("Index");
                else
                    return View(dogovorDAO.getDogovor(id));
            }
            catch
            {
                return View(dogovorDAO.getDogovor(id));
            }
        }
    }
}