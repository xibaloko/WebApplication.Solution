using Business;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceHost
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "GtiService" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione GtiService.svc ou GtiService.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class GtiService : IGtiService
    {
        private readonly CadastroBusiness cadastro = new CadastroBusiness();
        public void NovoCadastro(Cliente cliente)
        {
            cadastro.NovoCadastro(cliente);
        }
    }
}
