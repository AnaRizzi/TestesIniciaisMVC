using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultaMedicos.Models;

namespace ConsultaMedicos.Controllers
{
    public class MedicosController : Controller
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.ToList();
            //vai retornar uma lista do banco da tabela médicos
            
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            //cria os itens de seleção buscando os itens em cada tabela (tabela, valor do item e texto que aparecerá)
            ViewBag.IdCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IdEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade","Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,"IDEspecialidade","Nome", medico.IDEspecialidade);
            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            Medicos medico = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade","Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades,"IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medicos medico = db.Medicos.Find(id);
                db.Medicos.Remove(medico);
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