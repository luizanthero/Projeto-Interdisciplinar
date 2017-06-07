using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_AlterarProduto : System.Web.UI.Page
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
                        string produto = Request.QueryString["str"].ToString().Replace(" ", "+");
                        int n = Convert.ToInt32(produto);

                        Produto pro = ProdutoDB.Select(n);
                        txbId.Text = pro.Pro_id.ToString();
                        txbNome.Text = pro.Pro_nome;
                        txbPreco.Text = pro.Pro_preco.ToString();
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
        Produto pro = new Produto();
        pro.Pro_id = Convert.ToInt32(txbId.Text);
        pro.Pro_nome = txbNome.Text;
        pro.Pro_preco = Convert.ToDouble(txbPreco.Text);

        switch (ProdutoDB.Atualizar(pro))
        {
            case 0:
                Response.Redirect("~/paginas/ConsultarProduto.aspx");
                break;

            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbNome.Text = "";
        txbPreco.Text = "";
    }
}