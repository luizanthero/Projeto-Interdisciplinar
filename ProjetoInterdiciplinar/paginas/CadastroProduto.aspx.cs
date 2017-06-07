using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_CadastroProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Produto pro = new Produto();
        pro.Pro_nome = txbNome.Text;
        pro.Pro_preco = Convert.ToDouble(txbPreco.Text);

        switch (ProdutoDB.Insert(pro))
        {
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>success();</script>", false);
                break;

            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }

        txbNome.Text = "";
        txbPreco.Text = "";
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbNome.Text = "";
        txbPreco.Text = "";
    }
}