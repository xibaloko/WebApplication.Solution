using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForm.GtiServiceReference;

namespace WebForm
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGrid();
            };
            
            LblValidaCpf.Visible = false;
        }
        private void CarregaGrid()
        {
            List<Cliente> lstCliente;

            using (var svc = new GtiServiceClient())
            {
                lstCliente = svc.BuscarClientes();
            }

            GvCadastros.DataSource = lstCliente;
            GvCadastros.DataBind();
        }
        protected void Cadastrar_Command(object sender, CommandEventArgs e)
        {
            if (!ValidarCpf(Cpf.Value))
            {
                LblValidaCpf.Visible = true;
                return;
            }

            Cliente cliente = new Cliente()
            {
                Nome = Nome.Value,
                Cpf = Cpf.Value,
                Rg = RG.Value,
                DataExpedicao = DateTime.Parse(DataExpedicao.Value),
                UfExpedicao = UfExpedicao.Value,
                OrgaoExpedicao = OrgExpedicao.Value,
                DataNascimento = DateTime.Parse(DataNascimento.Value),
                EstadoCivil = EstadoCivil.SelectedValue,
                Sexo = Sexo.SelectedValue
            };

            cliente.Enderecos = new List<EnderecoCliente>();

            cliente.Enderecos.Add(new EnderecoCliente()
            {
                Cep = Cep.Value,
                Logradouro = Logradouro.Value,
                Numero = Numero.Value,
                Complemento = Complemento.Value,
                Bairro = Bairro.Value,
                Cidade = Cidade.Value,
                Uf = UF.Value
            });

            using (var svc = new GtiServiceClient())
            {
                svc.NovoCadastro(cliente);
            };

            LimparCampos();
            CarregaGrid();
        }
        protected void BtnAlterarCadastro_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            Cliente cliente;

            using (var svc = new GtiServiceClient())
            {
                cliente = svc.BuscarCliente(id);
            };

            Cpf.Value = cliente.Cpf;
            Nome.Value = cliente.Nome;
            RG.Value = cliente.Rg;
            DataExpedicao.Value = cliente.DataExpedicao.ToString("yyyy-MM-dd");
            OrgExpedicao.Value = cliente.OrgaoExpedicao;
            UfExpedicao.Value = cliente.UfExpedicao;
            DataNascimento.Value = cliente.DataNascimento.ToString("yyyy-MM-dd");
            Sexo.SelectedValue = cliente.Sexo;
            EstadoCivil.SelectedValue = cliente.EstadoCivil;

            EnderecoCliente endereco = cliente.Enderecos.SingleOrDefault();

            Cep.Value = endereco.Cep;
            Logradouro.Value = endereco.Logradouro;
            Numero.Value = endereco.Numero;
            Complemento.Value = endereco.Complemento;
            Bairro.Value = endereco.Bairro;
            Cidade.Value = endereco.Cidade;
            UF.Value = endereco.Uf;


            HiddenID.Value = id.ToString();
            Cadastrar.Visible = false;
            Atualizar.Visible = true;
        }
        protected void Atualizar_Command(object sender, CommandEventArgs e)
        {
            if (!ValidarCpf(Cpf.Value))
            {
                LblValidaCpf.Visible = true;
                return;
            }

            int id = int.Parse(HiddenID.Value);

            Cliente cliente = new Cliente()
            {
                Nome = Nome.Value,
                Cpf = Cpf.Value,
                Rg = RG.Value,
                DataExpedicao = DateTime.Parse(DataExpedicao.Value),
                UfExpedicao = UfExpedicao.Value,
                OrgaoExpedicao = OrgExpedicao.Value,
                DataNascimento = DateTime.Parse(DataNascimento.Value),
                EstadoCivil = EstadoCivil.SelectedValue,
                Sexo = Sexo.SelectedValue
            };

            cliente.Enderecos = new List<EnderecoCliente>();

            cliente.Enderecos.Add(new EnderecoCliente()
            {
                Cep = Cep.Value,
                Logradouro = Logradouro.Value,
                Numero = Numero.Value,
                Complemento = Complemento.Value,
                Bairro = Bairro.Value,
                Cidade = Cidade.Value,
                Uf = UF.Value
            });

            using (var svc = new GtiServiceClient())
            {
                svc.AtualizarCadastro(id, cliente);
            };

            HiddenID.Value = string.Empty;
            Cadastrar.Visible = true;
            Atualizar.Visible = false;

            LimparCampos();
            CarregaGrid();
        }
        protected void BtnExcluirCadastro_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            using (var svc = new GtiServiceClient())
            {
                svc.ExcluirCadastro(id);
            };

            CarregaGrid();
        }
        protected void LimparCampos()
        {
            Cpf.Value = string.Empty;
            Nome.Value = string.Empty;
            RG.Value = string.Empty;
            DataExpedicao.Value = string.Empty;
            OrgExpedicao.Value = string.Empty;
            UfExpedicao.Value = string.Empty;
            DataNascimento.Value = string.Empty;
            Cep.Value = string.Empty;
            Logradouro.Value = string.Empty;
            Numero.Value = string.Empty;
            Complemento.Value = string.Empty;
            Bairro.Value = string.Empty;
            Cidade.Value = string.Empty;
            UF.Value = string.Empty;
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