using Business;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace WCFServiceHost
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "GtiService" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione GtiService.svc ou GtiService.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class GtiService : IGtiService
    {
        private readonly CadastroBusiness cadastro = new CadastroBusiness();

        public void AtualizarCadastro(int id, Cliente cliente)
        {
            cadastro.AtualizarCadastro(id, cliente);
        }

        public Cliente BuscarCliente(int id)
        {
            return cadastro.BuscarCliente(id);
        }

        public List<Cliente> BuscarClientes()
        {
            return cadastro.BuscarClientes();
        }

        public void ExcluirCadastro(int id)
        {
            cadastro.ExcluirCadastro(id);
        }

        public void NovoCadastro(Cliente cliente)
        {
            cadastro.NovoCadastro(cliente);
        }
    }
}
