using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_AlterarPedido : System.Web.UI.Page
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
                        string pedido = Request.QueryString["str"].ToString().Replace(" ", "+");
                        int n = Convert.ToInt32(pedido);

                        Pedido ped = PedidoDB.Select(n);
                        Item ite = ItemDB.Select(n);
                        txbID.Text = ped.Ped_id.ToString();
                        txbQuantidade.Text = ite.Ite_quantidade.ToString();
                        txbFrete.Text = ped.Ped_frete.ToString();

                        DataSet ds = UsuarioDB.SelectAll(); ;
                        ddlUsu.DataSource = ds;
                        ddlUsu.DataTextField = "usu_nome";
                        // Nome da coluna do Banco de dados 
                        ddlUsu.DataValueField = "usu_id";
                        // ID da coluna do Banco 
                        ddlUsu.DataBind();
                        ddlUsu.Items.Insert(0, "Selecione");
                        UsuPed upd = UsuPedDB.SelectUsu(n);
                        ddlUsu.SelectedIndex = upd.Usuario.Usu_id;

                        DataSet ds1 = ProdutoDB.SelectAll(); ;
                        ddlProduto.DataSource = ds1;
                        ddlProduto.DataTextField = "pro_nome";
                        // Nome da coluna do Banco de dados 
                        ddlProduto.DataValueField = "pro_id";
                        // ID da coluna do Banco 
                        ddlProduto.DataBind();
                        ddlProduto.Items.Insert(0, "Selecione");
                        ddlProduto.SelectedIndex = ped.Produto.Pro_id;
                    }
                    catch (Exception erro)
                    {
                        Response.Redirect("~/paginas/ConsultarPedido.aspx");
                    }
                }
            }
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

        PedidoDB.Atualizar(ped);

        int n1 = ItemDB.Atualizar(ite, Convert.ToInt32(txbID.Text));

        if (n1 == 0)
        {
            Response.Redirect("~/paginas/ConsultarPedido.aspx");
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

    }
}