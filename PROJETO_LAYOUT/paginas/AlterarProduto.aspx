<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarProduto.aspx.cs" Inherits="paginas_AlterarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Alterar Produto</h3>
        <div class="row">
            <div class="col-lg-3">
                ID:<asp:TextBox ID="txbId" CssClass="form-control" runat="server" required="required" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                Nome:<asp:TextBox ID="txbNome" CssClass="form-control" runat="server" required="required" ></asp:TextBox>
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
        function error() {
            new PNotify({
                title: 'Atenção',
                text: 'Alteração não completado!',
                type: 'error'
            });
        }
    </script>
</asp:Content>

