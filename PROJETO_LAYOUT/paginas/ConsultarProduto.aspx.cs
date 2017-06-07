using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ConsultarProduto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = ProdutoDB.SelectAll();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                lbl.Text += "<div class='col-md-3 col-sm-8 col-xs-4 animated fadeInDown'>" +
                                        "<div class='well profile_view'>" +
                                            "<div class='modal-header'>" +
                                                "<h2 class='modal-title'>" + dr["pro_nome"] + "</h2>" +
                                            "</div>" +
                                            "<div class='modal-body'>" +
                                                "<ul class='list-unstyled'>" +
                                                    "<li>Código: " + dr["pro_id"] + "</li>" +
                                                    "<li>Preço: " + dr["pro_preco"] + "</li>" +
                                                "</ul>" +
                                            "</div>" +
                                            "<div class='divider'></div>" +
                                            "<div class='modal-footer2'>" +
                                                "<div class='col-xs-12 bottom text-center'>" +
                                                    "<a href='../paginas/AlterarProduto.aspx?str=" + dr["pro_id"] + "'>" +
                                                        "<button type='button' class='btn btn-primary btn-xs'>" +
                                                            " <i class='fa fa-edit'></i> Atualizar" +
                                                        "</button>" +
                                                    "</a>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +

                                "<div class='modal fade' id='myModalExcluir' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja Excluir?</h2>" +
                                              "</div>" +
                                              "<div class='modal-footer'>" +
                                                  "<div class='col-xs-12 bottom text-right'>" +
                                                      "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                      "<button type='button' class='btn btn-danger' onclick='Excluir(" + dr["pro_id"] + ")'>Sim</button>" +
                                                  "</div>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static void Excluir(int codigo)
    {
        Produto pro = new Produto();

        pro.Pro_id = codigo;


        PedidoDB.Excluir(pro);
        ProdutoDB.Excluir(pro);
    }
}