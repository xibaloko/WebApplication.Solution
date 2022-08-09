using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        private void PreecherDropDownLists(string sexo = null, string estadoCivil = null)
        {
            List<SelectListItem> lstSexo = new List<SelectListItem>();

            lstSexo.Add(new SelectListItem()
            {
                Text = "Masculino",
                Value = "M",
                Selected = sexo != null && sexo == "M" ? true : false
            });
            lstSexo.Add(new SelectListItem()
            {
                Text = "Feminino",
                Value = "F",
                Selected = sexo != null && sexo == "F" ? true : false
            });

            List<SelectListItem> lstEstadoCivil = new List<SelectListItem>();

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Solteiro(a)",
                Value = "Solteiro",
                Selected = estadoCivil != null && estadoCivil == "Solteiro" ? true : false
            });

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Casado(a)",
                Value = "Casado",
                Selected = estadoCivil != null && estadoCivil == "Casado" ? true : false
            });

            lstEstadoCivil.Add(new SelectListItem()
            {
                Text = "Divorciado(a)",
                Value = "Divorciado",
                Selected = estadoCivil != null && estadoCivil == "Divorciado" ? true : false
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
        public async Task<ActionResult> Create(Cliente model)
        {
            try
            {
                await api.PostCliente(model, HttpMethod.Post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastro/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            
            var cliente = await api.GetCliente(id);

            PreecherDropDownLists(cliente.Sexo, cliente.EstadoCivil);

            return View(cliente);
        }

        // POST: Cadastro/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Cliente model, FormCollection collection)
        {

            try
            {
                await api.PutCliente(id, model, HttpMethod.Put);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cadastro/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await api.GetCliente(id);

            return View(cliente);
        }

        // POST: Cadastro/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                await api.DeleteCliente(id, HttpMethod.Delete);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
