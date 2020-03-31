using ConsultaMedicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ConsultaMedicos.Controllers
{
    public class CidadesController : Controller
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Cidades
        public ActionResult Index()
        {
            var cidade = db.Cidades.ToList();
            return View(cidade);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(cidade);
        }

        public ActionResult Editar(int id)
        {
            Cidades cidade = db.Cidades.Find(id);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(Cidades cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }
        
        public string Excluir(int id)
        {
            try
            {
                Cidades cidade = db.Cidades.Find(id);
                db.Cidades.Remove(cidade);
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