<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebForm.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="mt-4">
            <h3>Cliente</h3>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="Cpf" class="form-label">CPF</label>
                <input type="text" runat="server" id="Cpf" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Cpf" ErrorMessage="Preencha o Campo" ForeColor="Red" />
            </div>
            <div class="col-md-9">
                <label for="Nome" class="form-label">Nome</label>
                <input type="text" runat="server" id="Nome" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nome" ErrorMessage="Preencha o Campo" ForeColor="Red" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="RG" class="form-label">RG</label>
                <input type="text" runat="server" id="RG" class="form-control" />
            </div>
            <div class="col-md-3">
                <label for="DataExpedicao" class="form-label">Data Expedição</label>
                <input type="date" runat="server" id="DataExpedicao" class="form-control" />
            </div>
            <div class="col-md-3">
                <label for="OrgExpedicao" class="form-label">Órgão Expedição</label>
                <input type="text" runat="server" id="OrgExpedicao" class="form-control" />
            </div>
            <div class="col-md-3">
                <label for="UfExpedicao" class="form-label">Uf Expedição</label>
                <input type="text" runat="server" id="UfExpedicao" class="form-control" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="DataNascimento" class="form-label">Data Nascimento</label>
                <input type="date" runat="server" id="DataNascimento" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="DataNascimento" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
            <div class="col-md-3">
                <label for="Sexo" class="form-label">Sexo</label>
                <asp:DropDownList ID="Sexo" runat="server" CssClass="form-select">
                    <asp:ListItem Value="M" Text="Masculino" Selected="True" />
                    <asp:ListItem Value="F" Text="Feminino" />
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <label for="EstadoCivil" class="form-label">Estado Civil</label>
                <asp:DropDownList ID="EstadoCivil" runat="server" CssClass="form-select">
                    <asp:ListItem Value="Solteiro" Text="Solteiro(a)" Selected="True" />
                    <asp:ListItem Value="Casado" Text="Casado(a)" />
                    <asp:ListItem Value="Divorciado" Text="Divorciado(a)" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="mt-4">
            <h3>Endereço</h3>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="Cep" class="form-label">CEP</label>
                <input type="text" runat="server" id="Cep" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Cep" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
            <div class="col-md-6">
                <label for="Logradouro" class="form-label">Rua</label>
                <input type="text" runat="server" id="Logradouro" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Logradouro" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
            <div class="col-md-3">
                <label for="Numero" class="form-label">Numero</label>
                <input type="text" runat="server" id="Numero" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Numero" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="Complemento" class="form-label">Complemento</label>
                <input type="text" runat="server" id="Complemento" class="form-control" />
            </div>
            <div class="col-md-3">
                <label for="Bairro" class="form-label">Bairro</label>
                <input type="text" runat="server" id="Bairro" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Bairro" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
            <div class="col-md-3">
                <label for="Cidade" class="form-label">Cidade</label>
                <input type="text" runat="server" id="Cidade" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Cidade" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
            <div class="col-md-3">
                <label for="UF" class="form-label">UF</label>
                <input type="text" runat="server" id="UF" class="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UF" ErrorMessage="Preencha o Campo" ForeColor="Red" />

            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-12 text-end">
                <asp:Button ID="Cadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-dark btn-lg" OnCommand="Cadastrar_Command" />
            </div>
        </div>

        <div class="row mt-5">
            <div class="col-md-9">
                <asp:GridView ID="GvCadastros" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
                    <Columns>
                        <%--<asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                        <asp:BoundField HeaderText="Data Lançamento" DataField="DataLancamento" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Valor" DataField="Valor" />
                        <asp:TemplateField HeaderText="Ação">
                            <ItemTemplate>
                                <asp:ImageButton ID="BtnDeletarLancamento" runat="server" ImageUrl="img/baseline_clear_black_24dp.png" CommandArgument='<%#Eval("IdLancamento")%>' OnCommand="BtnDeletarLancamento_Command" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
