using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_AlterarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["str"] != null)
            {
                if (Request.QueryString["str"].ToString() != "")
                {

                    try
                    {
                        string usuario = Request.QueryString["str"].ToString().Replace(" ", "+");
                        int n = Convert.ToInt32(usuario);

                        Usuario usu = UsuarioDB.Select(n);
                        txbId.Text = usu.Usu_id.ToString();
                        txbNome.Text = usu.Usu_nome;
                        txbEmail.Text = usu.Usu_email;
                        txbSenha.Text = usu.Usu_senha;

                        DataSet ds = PerfilDB.SelectAll(); ;
                        ddlPerfil.DataSource = ds;
                        ddlPerfil.DataTextField = "per_tipo";
                        // Nome da coluna do Banco de dados 
                        ddlPerfil.DataValueField = "per_id";
                        // ID da coluna do Banco 
                        ddlPerfil.DataBind();
                        ddlPerfil.Items.Insert(0, "Selecione");
                        ddlPerfil.SelectedIndex = usu.Perfil.Per_id;
                    }
                    catch (Exception erro)
                    {
                        Response.Redirect("~/paginas/ConsultarUsuario.aspx");
                    }
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        usu.Usu_id = Convert.ToInt32(txbId.Text);
        usu.Usu_nome = txbNome.Text;
        usu.Usu_email = txbEmail.Text;
        usu.Usu_senha = txbSenha.Text;
        usu.Perfil = new Perfil();
        usu.Perfil.Per_id = Convert.ToInt32(ddlPerfil.SelectedValue);
        switch (UsuarioDB.Atualizar(usu))
        {
            case 0:
                Response.Redirect("~/paginas/ConsultarUsuario.aspx");
                break;

            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbNome.Text = "";
        txbEmail.Text = "";
        txbSenha.Text = "";
        ddlPerfil.SelectedIndex = 0;
    }
}