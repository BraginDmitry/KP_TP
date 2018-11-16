using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.DAO;

namespace TP.Controllers
{
    public class HomeController : Controller
    {
        GroupDogDAO groupDAO = new GroupDogDAO();
        DogovorDAO recordsDAO = new DogovorDAO();

/*      protected bool ValidateRecords(Biblo BibloToValidate)
        {
            if (BibloToValidate.FIO == null)
                ModelState.AddModelError("FIO", "Поле 'Фамилия, Имя, Отчество ' обязательно для заполнения.");
            if (BibloToValidate.Avtor == null)
                ModelState.AddModelError("Avtor", "Поле 'Автор книги' обязательно для заполнения.");
            if (BibloToValidate.Book == null)
                ModelState.AddModelError("Book", "Поле 'Название книги' обязательно для заполнения.");
            if (BibloToValidate.Librarian == null)
                ModelState.AddModelError("Librarian", "Поле 'Библиотекарь' обязательно для заполнения.");
            if (BibloToValidate.Date == null)
                ModelState.AddModelError("Date", "Поле 'Дата' обязательно для заполнения.");
            return ModelState.IsValid;
        }*/


        public ActionResult Index(int? id)
        {
            ViewData["Groups"] = groupDAO.GetAllGroups();
            var records = id == null ? recordsDAO.GetAllDogovor() : recordsDAO.GetAllDogovor().Where(x => x.GroupDog.Id == id);
            if (!Request.IsAjaxRequest())
                // Normal Request
                return View(records);
            else
                // Ajax Request
                return PartialView("DogovorList", records);

        }
/*
        public ActionResult Details(int id)
        {
            return View(recordsDAO.getRecords(id));
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
        public ActionResult Create(int GroupId, [Bind(Exclude = "Id")] Biblo Records)
        {
            ViewDataSelectList(GroupId);


            try
            {
                if (ValidateRecords(Records) && recordsDAO.addRecords(GroupId, Records))
                    return RedirectToAction("Index");
                else
                    return View(Records);
            }
            catch
            {
                return View(Records);
            }

        }

        public ActionResult Edit(int id)
        {
            Biblo Records = recordsDAO.getRecords(id);
            if (!ViewDataSelectList(Records.Groups.Id))
                return RedirectToAction("Index");
            return View(recordsDAO.getRecords(id));
        }

        [HttpPost]
        public ActionResult Edit(int GroupId, Biblo Records)
        {
            ViewDataSelectList(-1);
            try
            {
                if (ModelState.IsValid && recordsDAO.updateRecords(GroupId, Records))
                    return RedirectToAction("Index");
                else
                    return View(Records);
            }
            catch
            {
                return View(Records);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(recordsDAO.getRecords(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Biblo Records)
        {
            try
            {
                if (recordsDAO.deleteRecords(id))
                    return RedirectToAction("Index");
                else
                    return View(recordsDAO.getRecords(id));
            }
            catch
            {
                return View(recordsDAO.getRecords(id));
            }
        }*/
    }
}