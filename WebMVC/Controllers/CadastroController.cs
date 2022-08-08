using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class CadastroController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<SelectListItem> lstSexo = new List<SelectListItem>();

            lstSexo.Append(new SelectListItem()
            {
                Text = "Masculino",
                Value = "M"
            });
            lstSexo.Append(new SelectListItem()
            {
                Text = "Feminino",
                Value = "F"
            });

            IEnumerable<SelectListItem> lstEstadoCivil = new List<SelectListItem>();

            lstEstadoCivil.Append(new SelectListItem()
            {
                Text = "Casado(a)",
                Value = "Casado"
            }) ;

            lstEstadoCivil.Append(new SelectListItem()
            {
                Text = "Solteiro(a)",
                Value = "Solteiro"
            });

            lstEstadoCivil.Append(new SelectListItem()
            {
                Text = "Divorciado(a)",
                Value = "Divorciado"
            });

            ViewBag.Sexo = lstSexo;
            ViewBag.EstadoCivil = lstEstadoCivil;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Cliente model)
        {
            return View();
        }

        // GET: Cadastro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cadastro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cadastro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
