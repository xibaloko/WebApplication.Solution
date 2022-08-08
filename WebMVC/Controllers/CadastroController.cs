using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMVC.Util;

namespace WebMVC.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Api api = new Api();
        
        public async Task<ActionResult> Index()
        {
            var clientes = await api.GetClientes();

            return View(clientes);
        }


        private void PreecherDropDownLists()
        {
            List<SelectListItem> lstSexo = new List<SelectListItem>();

            lstSexo.Add(new SelectListItem()
            {
                Text = "Masculino",
                Value = "M"
            });
            lstSexo.Add(new SelectListItem()
            {
                Text = "Feminino",
                Value = "F"
            });

            List<SelectListItem> lstEstadoCivil = new List<SelectListItem>();

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Casado(a)",
                Value = "Casado"
            });

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Solteiro(a)",
                Value = "Solteiro"
            });

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Divorciado(a)",
                Value = "Divorciado"
            });

            ViewBag.Sexo = new MultiSelectList(lstSexo.ToList(), "Value", "Text");
            ViewBag.EstadoCivil = new MultiSelectList(lstEstadoCivil.ToList(), "Value", "Text");
        }


        // GET: Cadastro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cadastro/Create
        public ActionResult Create()
        {

            PreecherDropDownLists();

            return View();
        }

        // POST: Cadastro/Create
        [HttpPost]
        public ActionResult Create(Cliente model)
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
