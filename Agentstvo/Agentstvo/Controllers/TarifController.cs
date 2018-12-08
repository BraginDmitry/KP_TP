using Agentstvo.DAO;
using Agentstvo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agentstvo.Controllers
{
    public class TarifController : Controller
    {
        TarifDAO tarifDAO = new TarifDAO();
        List<Tarif> tarif;

        [HttpGet]

        public ActionResult Index()
        {
            return View(tarifDAO.GetAllTarif());
        }

        [HttpGet]	// Атрибут, используемый для ограничения метода таким образом, чтобы этот метод обрабатывал только HTTP-заппросы GET
        public ActionResult Details(int id)
        {
            tarif = tarifDAO.GetAllTarif();
            int trueid = 0;
            for (int i = 0; i < tarif.Count; i++) if (tarif[i].Id == id) trueid = i;
            return View(tarif[trueid]);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost] // Атрибут, используемый для ограничения метода таким образом, чтобы этот метод обрабатывал только HTTP-запросы Post
        public ActionResult Create([Bind(Exclude = "Id")]Tarif tarif)
        {
            try
            {
                if (tarifDAO.AddTarif(tarif))
                {
                    return RedirectToAction("Index");
                }
                else
                {

                    return View("Создать");
                }
            }
            catch
            {
                return View("Создать");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            tarif = tarifDAO.GetAllTarif();
            int trueid = 0;
            for (int i = 0; i < tarif.Count; i++) if (tarif[i].Id == id) trueid = i;
            return View(tarif[trueid]);
        }


        [HttpPost]
        public ActionResult Edit(Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                tarifDAO.EditTarif(tarif);
                return View("Index");
            }
            else
            {
                return View("Ошибка");
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                tarif = tarifDAO.GetAllTarif();
                int trueid = 0;
                for (int i = 0; i < tarif.Count; i++) if (tarif[i].Id == id) trueid = i;
                return View(tarif[trueid]);
            }
            catch
            {
                return View("Ошибка");
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                int rec_id = Convert.ToInt32(id);
                tarifDAO.DeleteTarif(rec_id);
                return View("Index");
            }
            catch
            {
                return View("Ошибка");
            }
        }

    }
}
