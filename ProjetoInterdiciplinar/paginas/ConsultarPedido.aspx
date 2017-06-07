<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarPedido.aspx.cs" Inherits="paginas_ConsultarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Consulta de Pedidos</h3>
        <asp:Button ID="btn" runat="server" OnClick="btn_Click" CssClass="btn btn-primary" Text="Ordenar" />
        <br />
        <br />
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </div>
    <script>
        function Excluir(codigo) {
            var jsonText = JSON.stringify({ codigo: codigo });
            $.ajax({
                type: 'POST',
                url: 'ConsultarPedido.aspx/Excluir',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultarPedido.aspx";
                }
            });
        }
    </script>
</asp:Content>

