using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceHost
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IGtiService" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IGtiService
    {
        [OperationContract]
        void NovoCadastro(Cliente cliente);
    }
}
