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
                if (ValidarCpf(model.Cpf))
                {
                    await api.PostCliente(model, HttpMethod.Post);

                    return RedirectToAction("Index");
                }

                ViewBag.JavaScriptFunction = string.Format("CpfInvalido();");
                
                PreecherDropDownLists();
                return View();
            }
            catch
            {
                PreecherDropDownLists();
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

        /** Método Referência Macoratti - https://www.macoratti.net/11/09/c_val1.htm **/
        private bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
