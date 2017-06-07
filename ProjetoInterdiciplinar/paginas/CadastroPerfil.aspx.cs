using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_CadastroPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Perfil per = new Perfil();
        per.Per_tipo = txbPerfil.Text;

        switch (PerfilDB.Insert(per))
        {
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>success();</script>", false);
                break;

            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }

        txbPerfil.Text = "";
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbPerfil.Text = "";
    }
}