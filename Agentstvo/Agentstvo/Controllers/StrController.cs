using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agentstvo.DAO;
using Agentstvo.Model;

namespace Agentstvo.Controllers
{
    public class StrController : Controller
    {
        GroupStrDAO groupDAO = new GroupStrDAO();
        StrSlDAO strslDAO = new StrSlDAO();

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
            var strsl = id == null ? strslDAO.GetAllStrSl() : strslDAO.GetAllStrSl().Where(x => x.GroupStr.Id == id);
            if (!Request.IsAjaxRequest())
                // Normal Request
                return View(strsl);
            else
                // Ajax Request
                return PartialView("StrSlList", strsl);

        }


        public ActionResult Details(int id)
        {
            return View(strslDAO.getStrSl(id));
        }
        protected bool ViewDataSelectList(int GroupId)
        {
            var groups = groupDAO.GetAllGroups();
            ViewData["GroupId"] = new SelectList(groups, "Id", "Name", GroupId);
            return groups.Count() > 0;
        }

        public ActionResult Create()
        {
            if (!ViewDataSelectList(-1))
                return RedirectToAction("Index");
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(int GroupId, [Bind(Exclude = "Id")] StrSl Str)
        {
            ViewDataSelectList(GroupId);


            try
            {
                if (strslDAO.addSrtSl(GroupId, Str))
                    return RedirectToAction("Index");
                else
                    return View(Str);
            }
            catch
            {
                return View(Str);
            }

        }

        public ActionResult Edit(int id)
        {
            StrSl Str = strslDAO.getStrSl(id);
            if (!ViewDataSelectList(Str.GroupStr.Id))
                return RedirectToAction("Index");
            return View(strslDAO.getStrSl(id));
        }

        [HttpPost]
        public ActionResult Edit(int GroupId, StrSl Str)
        {
            ViewDataSelectList(-1);
            try
            {
                if (ModelState.IsValid && strslDAO.updateStrSl(GroupId, Str))
                    return RedirectToAction("Index");
                else
                    return View(Str);
            }
            catch
            {
                return View(Str);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(strslDAO.getStrSl(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, StrSl Str)
        {
            try
            {
                if (strslDAO.deleteStrSl(id))
                    return RedirectToAction("Index");
                else
                    return View(strslDAO.getStrSl (id));
            }
            catch
            {
                return View(strslDAO.getStrSl(id));
            }
        }
    }
}
