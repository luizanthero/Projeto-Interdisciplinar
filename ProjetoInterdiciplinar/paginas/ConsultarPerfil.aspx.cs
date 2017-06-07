using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ConsultarPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = PerfilDB.SelectAll();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lbl.Text += "<div class='col-md-3 col-sm-8 col-xs-4 animated fadeInDown'>" +
                                        "<div class='well profile_view'>" +
                                            "<div class='modal-header'>" +
                                                "<h2 class='modal-title'>" + dr["per_tipo"] + "</h2>" +
                                            "</div>" +
                                            "<div class='modal-body'>" +
                                                "<ul class='list-unstyled'>" +
                                                    "<li>Código: " + dr["per_id"] + "</li>" +
                                                "</ul>" +
                                            "</div>" +
                                            "<div class='divider'></div>" +
                                            "<div class='modal-footer2'>" +
                                                "<div class='col-xs-12 bottom text-center'>" +
                                                    "<a href='../paginas/AlterarPerfil.aspx?str=" + dr["per_id"] + "'>" +
                                                        "<button type='button' class='btn btn-primary btn-xs'>" +
                                                            " <i class='fa fa-edit'></i> Atualizar" +
                                                        "</button>" +
                                                    "</a>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>";
            }
        }
    }
}