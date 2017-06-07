using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ConsultarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = UsuarioDB.SelectAll();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Perfil per = PerfilDB.Select(Convert.ToInt32(dr["per_id"]));

                lbl.Text += "<div class='col-md-3 col-sm-8 col-xs-4 animated fadeInDown'>" +
                                        "<div class='well profile_view'>" +
                                            "<div class='modal-header'>" +
                                                "<h2 class='modal-title'>" + dr["usu_nome"] + "</h2>" +
                                            "</div>" +
                                            "<div class='modal-body'>" +
                                                "<ul class='list-unstyled'>" +
                                                    "<li>Código: " + dr["usu_id"] + "</li>" +
                                                    "<li>Email: " + dr["usu_email"] + "</li>" +
                                                    "<li>Perfil: " + per.Per_tipo + "</li>" +
                                                "</ul>" +
                                            "</div>" +
                                            "<div class='divider'></div>" +
                                            "<div class='modal-footer2'>" +
                                                "<div class='col-xs-12 bottom text-center'>" +
                                                    "<a href='../paginas/AlterarUsuario.aspx?str=" + dr["usu_id"] + "'>" +
                                                        "<button type='button' class='btn btn-primary btn-xs'>" +
                                                            " <i class='fa fa-edit'></i> Atualizar" +
                                                        "</button>" +
                                                    "</a>" +
                                                    "<button type = 'button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalExcluir" + dr["usu_id"] + "'>" +
                                                        "<i class='fa fa-trash'></i> Excluir " +
                                                    "</button>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +

                                "<div class='modal fade' id='myModalExcluir" + dr["usu_id"] + "' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
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
                                                      "<button type='button' class='btn btn-danger' onclick='Excluir(" + dr["usu_id"] + ")'>Sim</button>" +
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
        Usuario usu = new Usuario();
        UsuPed upd = UsuPedDB.Select(codigo);

        usu.Usu_id = codigo;

        UsuPedDB.Excluir(usu);
        UsuarioDB.Excluir(usu);
    }
}