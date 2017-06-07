<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarProduto.aspx.cs" Inherits="paginas_ConsultarProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Consulta de Produtos</h3>
        <br />
        <br />
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </div>

    <script>
        function desativar(codigo) {
            var jsonText = JSON.stringify({ codigo: codigo });
            $.ajax({
                type: 'POST',
                url: 'ConsultarProduto.aspx/Excluir',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultarProduto.aspx";
                }
            });
        }
    </script>
</asp:Content>

