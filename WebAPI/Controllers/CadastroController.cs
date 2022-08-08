using Business;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CadastroController : ApiController
    {
        public readonly CadastroBusiness cadastroBusiness = new CadastroBusiness();
        
        // GET: api/Cadastro
        public IHttpActionResult GetClientes()
        {
            IEnumerable<Cliente> clientes = cadastroBusiness.BuscarClientes();

            if (clientes != null)
            {
                return Ok(clientes);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: api/Cadastro/5
        public IHttpActionResult GetCliente(int id)
        {
            Cliente cliente = cadastroBusiness.BuscarCliente(id);

            if (cliente != null)
            {
                return Ok(cliente);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cadastro
        public IHttpActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                cadastroBusiness.NovoCadastro(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Cadastro/5
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente)
        {
            try
            {
                cadastroBusiness.AtualizarCadastro(id, cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Cadastro/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                cadastroBusiness.ExcluirCadastro(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
