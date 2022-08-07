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
                <%--<asp:TextBox ID="Cpf" runat="server" CssClass="form-control" />--%>
                <input type="text" runat="server" id="Cpf" class="form-control" />
            </div>
            <div class="col-md-9">
                <label for="Nome" class="form-label">Nome</label>
                <asp:TextBox ID="Nome" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-3">
                <label for="RG" class="form-label">RG</label>
                <asp:TextBox ID="RG" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label for="DataExpedicao" class="form-label">Data Expedição</label>
                <input type="date" runat="server" id="DataExpedicao" class="form-control" />
            </div>
            <div class="col-md-3">
                <label for="OrgExpedicao" class="form-label">Órgão Expedição</label>
                <asp:TextBox ID="OrgExpedicao" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label for="UfExpedicao" class="form-label">Uf Expedição</label>
                <asp:TextBox ID="UfExpedicao" runat="server" CssClass="form-control" />
            </div>
        </div>
            
    </div>
</asp:Content>
