﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroUsuario.aspx.cs" Inherits="paginas_CadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Cadastro de Usuario</h3>
        <div class="row">
            <div class="col-lg-3">
                Nome:<asp:TextBox ID="txbNome" CssClass="form-control" runat="server" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                E-Mail:<asp:TextBox ID="txbEmail" CssClass="form-control" runat="server" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                Senha:<asp:TextBox ID="txbSenha" CssClass="form-control" TextMode="Password" runat="server" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                Confirmar Senha:<asp:TextBox ID="txbConfirmar" CssClass="form-control" TextMode="Password" runat="server" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                Perfil:<asp:DropDownList ID="ddlPerfil" CssClass="form-control" runat="server" ></asp:DropDownList>
            </div>
        </div>
        
        <div class="row">
            <div class="col-lg-offset-1">
                <br />
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click" />
                <asp:Button ID="btnDeletar" runat="server" Text="Deletar" CssClass="btn btn-danger " OnClick="btnDeletar_Click" />
            </div>
        </div>
    </div>

    <script src="<%=ResolveUrl("~/js/pnotify.custom.min.js")%>"></script>

    <script type="text/javascript">
        function success() {
            new PNotify({
                title: 'Sucesso',
                text: 'Cadastro completo com sucesso!',
                type: 'success'
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            new PNotify({
                title: 'Atenção',
                text: 'Cadastro não completado!',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            new PNotify({
                title: 'Atenção',
                text: 'Senhas não são iguais!',
                type: 'warning'
            });
        }
    </script>
</asp:Content>

