<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastroProduto.aspx.cs" Inherits="paginas_CadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Cadastro de Produto</h3>
        <div class="row">
            <div class="col-lg-3">
                Nome:<asp:TextBox ID="txbNome" CssClass="form-control" runat="server" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                Preço:<asp:TextBox ID="txbPreco" runat="server" CssClass="form-control" required="required"></asp:TextBox>
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

