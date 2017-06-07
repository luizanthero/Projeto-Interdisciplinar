<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Comprar.aspx.cs" Inherits="paginas_Comprar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Comprar</h3>
        <div class="row">
            <div class="col-lg-3">
                Usuário:<asp:DropDownList ID="ddlUsu" CssClass="form-control" runat="server" ></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                Produto:<asp:DropDownList ID="ddlProduto" runat="server" CssClass="form-control" ></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                Quantidade:<asp:TextBox ID="txbQuantidade" runat="server" CssClass="form-control" required="required"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                Frete:<asp:TextBox ID="txbFrete" runat="server" CssClass="form-control" required="required" Enabled="false"></asp:TextBox>
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

