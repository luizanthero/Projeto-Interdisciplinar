<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarUsuario.aspx.cs" Inherits="paginas_ConsultarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="min-height: 480px">
        <h3>Consulta de Usuário</h3>
        <br />
        <br />
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </div>

    <script>
        function Excluir(codigo) {
            var jsonText = JSON.stringify({ codigo: codigo });
            $.ajax({
                type: 'POST',
                url: 'ConsultarUsuario.aspx/Excluir',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultarUsuario.aspx";
                }
            });
        }
    </script>
</asp:Content>

