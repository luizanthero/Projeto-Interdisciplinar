<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroPerfil.aspx.cs" Inherits="paginas_CadastroPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Cadastro de Perfil</h3>
        <div class="row">
            <div class="col-lg-3">
                Perfil:<asp:TextBox ID="txbPerfil" CssClass="form-control" runat="server" required="required"></asp:TextBox>
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
</asp:Content>

