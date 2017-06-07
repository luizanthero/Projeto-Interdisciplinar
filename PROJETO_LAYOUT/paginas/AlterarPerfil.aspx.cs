using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_AlterarPerfil : System.Web.UI.Page
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
                        string perfil = Request.QueryString["str"].ToString().Replace(" ", "+");
                        int n = Convert.ToInt32(perfil);

                        Perfil per = PerfilDB.Select(n);
                        txbId.Text = per.Per_id.ToString();
                        txbPerfil.Text = per.Per_tipo;
                    }
                    catch (Exception erro)
                    {
                        Response.Redirect("~/paginas/ConsultarProduto.aspx");
                    }
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Perfil per = new Perfil();
        per.Per_id = Convert.ToInt32(txbId.Text);
        per.Per_tipo = txbPerfil.Text;

        switch (PerfilDB.Atualizar(per))
        {
            case 0:
                Response.Redirect("~/paginas/ConsultarPerfil.aspx");
                break;

            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbPerfil.Text = "";
    }
}