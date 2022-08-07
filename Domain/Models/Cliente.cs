using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataExpedicao {get; set;}
        public string OrgaoExpedicao { get; set; }
        public string UfExpedicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public List<EnderecoCliente> Enderecos { get; set; }
    }
}
