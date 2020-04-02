using ConsultaMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ConsultaMedicos.Controllers
{
    public class EspecialidadesController : BaseController
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Especialidades
        public ActionResult Index()
        {
            var espec = db.Especialidades.ToList();
            return View(espec);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidade);
        }

        public ActionResult Editar(int id)
        {
            Especialidades especialidade = db.Especialidades.Find(id);
            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades especialidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidade);
        }

        public string Excluir(int id)
        {
            try
            {
                Especialidades especialidade = db.Especialidades.Find(id);
                db.Especialidades.Remove(especialidade);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
    }
}