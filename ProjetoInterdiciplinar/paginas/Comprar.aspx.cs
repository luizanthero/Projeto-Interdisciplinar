using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Comprar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = UsuarioDB.SelectAll(); ;
            ddlUsu.DataSource = ds;
            ddlUsu.DataTextField = "usu_nome";
            // Nome da coluna do Banco de dados 
            ddlUsu.DataValueField = "usu_id";
            // ID da coluna do Banco 
            ddlUsu.DataBind();
            ddlUsu.Items.Insert(0, "Selecione");

            DataSet ds1 = ProdutoDB.SelectAll(); ;
            ddlProduto.DataSource = ds1;
            ddlProduto.DataTextField = "pro_nome";
            // Nome da coluna do Banco de dados 
            ddlProduto.DataValueField = "pro_id";
            // ID da coluna do Banco 
            ddlProduto.DataBind();
            ddlProduto.Items.Insert(0, "Selecione");

            Random r = new Random();
            txbFrete.Text = r.Next(5, 30).ToString();
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Pedido ped = new Pedido();
        ped.Produto = new Produto();
        ped.Ped_frete = Convert.ToInt32(txbFrete.Text);
        ped.Ped_status = "Aguardando Pagamento";
        ped.Produto.Pro_id = Convert.ToInt32(ddlProduto.SelectedValue);

        Item ite = new Item();
        ite.Pedido = ped;
        ite.Ite_quantidade = Convert.ToInt32(txbQuantidade.Text);

        int aux = PedidoDB.Insert(ped);

        int n1 = ItemDB.Insert(ite, aux);
        int n2 = UsuPedDB.Insert(Convert.ToInt32(ddlUsu.SelectedValue), aux);

        if((n1 + n2) == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>success();</script>", false);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
        }

        txbQuantidade.Text = "";
        Random r = new Random();
        txbFrete.Text = r.Next(5, 30).ToString();
        ddlProduto.SelectedIndex = 0;
        ddlUsu.SelectedIndex = 0;
    }

    protected void btnDeletar_Click(object sender, EventArgs e)
    {
        txbQuantidade.Text = "";
        txbFrete.Text = "";
        ddlProduto.SelectedIndex = 0;
        ddlUsu.SelectedIndex = 0;
    }
}