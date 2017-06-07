using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_CadastroUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = PerfilDB.SelectAll(); ;
            ddlPerfil.DataSource = ds;
            ddlPerfil.DataTextField = "per_tipo";
            // Nome da coluna do Banco de dados 
            ddlPerfil.DataValueField = "per_id";
            // ID da coluna do Banco 
            ddlPerfil.DataBind();
            ddlPerfil.Items.Insert(0, "Selecione");
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        int aux = 0;
        Usuario usu = new Usuario();
        usu.Usu_nome = txbNome.Text;
        usu.Usu_email = txbEmail.Text;
        if (txbSenha.Text != txbConfirmar.Text)
        {
            aux = 1;
        }
        usu.Perfil = new Perfil();
        usu.Perfil.Per_id = Convert.ToInt32(ddlPerfil.SelectedValue);
        if (aux == 0)
        {
            usu.Usu_senha = txbSenha.Text;
            switch (UsuarioDB.Insert(usu))
            {
                case 0:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>success();</script>", false);
                    break;

                case -2:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                    break;
            }

            txbNome.Text = "";
            txbEmail.Text = "";
            txbSenha.Text = "";
            txbConfirmar.Text = "";
            ddlPerfil.SelectedIndex = 0;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbNome.Text = "";
        txbEmail.Text = "";
        txbSenha.Text = "";
        txbConfirmar.Text = "";
        ddlPerfil.SelectedIndex = 0;
    }
}