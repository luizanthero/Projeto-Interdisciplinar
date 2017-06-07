using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ConsultarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lbl.Text = CarregarLabel();
        }
    }

    protected String CarregarLabel()
    {
        DataSet ds = PedidoDB.SelectAll();
        List<string> fila = new List<string>();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            Item ite = ItemDB.Select(Convert.ToInt32(dr["ped_id"]));
            Produto pro = ProdutoDB.Select(Convert.ToInt32(dr["pro_id"]));

            fila.Add("<div class='hidden'>" + (pro.Pro_preco * ite.Ite_quantidade) + "</div><div class='col-md-3 col-sm-8 col-xs-4 animated fadeInDown'>" +
                                    "<div class='well profile_view'>" +
                                        "<div class='modal-header'>" +
                                            "<h2 class='modal-title'>Código: " + dr["ped_id"] + "</h2>" +
                                        "</div>" +
                                        "<div class='modal-body'>" +
                                            "<ul class='list-unstyled'>" +
                                                "<li>Produto: " + pro.Pro_nome + "</li>" +
                                                "<li>Frete: " + dr["ped_frete"] + "</li>" +
                                                "<li>Status: " + dr["ped_status"] + "</li>" +
                                                "<li>Quantidade: " + ite.Ite_quantidade + "</li>" +
                                                "<li>Valor Unitário: R$" + pro.Pro_preco + "</li>" +
                                                "<li>Valor Total: R$" + (pro.Pro_preco * ite.Ite_quantidade) + "</li>" +
                                            "</ul>" +
                                        "</div>" +
                                        "<div class='divider'></div>" +
                                        "<div class='modal-footer2'>" +
                                            "<div class='col-xs-12 bottom text-center'>" +
                                                "<a href='../paginas/AlterarPedido.aspx?str=" + dr["ped_id"] + "'>" +
                                                    "<button type='button' class='btn btn-primary btn-xs'>" +
                                                        " <i class='fa fa-edit'></i> Atualizar" +
                                                    "</button>" +
                                                "</a>" +
                                                "<button type = 'button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalExcluir" + dr["ped_id"] + "'>" +
                                                    "<i class='fa fa-trash'></i> Excluir " +
                                                "</button>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +

                            "<div class='modal fade' id='myModalExcluir" + dr["ped_id"] + "' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
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
                                                  "<button type='button' class='btn btn-danger' onclick='Excluir(" + dr["ped_id"] + ")'>Sim</button>" +
                                              "</div>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>" +
                                    "</div>");

            
        }

        string retorno = "";
        foreach(string texto in fila)
        {
            retorno += texto;
        }
        return retorno;
    }

    protected String CarregarLabelOrdenada()
    {
        DataSet ds = PedidoDB.SelectAll();
        List<string> fila = new List<string>();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            Item ite = ItemDB.Select(Convert.ToInt32(dr["ped_id"]));
            Produto pro = ProdutoDB.Select(Convert.ToInt32(dr["pro_id"]));

            fila.Add("<div class='hidden'>" + (pro.Pro_preco * ite.Ite_quantidade) + "</div><div class='col-md-3 col-sm-8 col-xs-4 animated fadeInDown'>" +
                                    "<div class='well profile_view'>" +
                                        "<div class='modal-header'>" +
                                            "<h2 class='modal-title'>Código: " + dr["ped_id"] + "</h2>" +
                                        "</div>" +
                                        "<div class='modal-body'>" +
                                            "<ul class='list-unstyled'>" +
                                                "<li>Produto: " + pro.Pro_nome + "</li>" +
                                                "<li>Frete: " + dr["ped_frete"] + "</li>" +
                                                "<li>Status: " + dr["ped_status"] + "</li>" +
                                                "<li>Quantidade: " + ite.Ite_quantidade + "</li>" +
                                                "<li>Valor Unitário: R$" + pro.Pro_preco + "</li>" +
                                                "<li>Valor Total: R$" + (pro.Pro_preco * ite.Ite_quantidade) + "</li>" +
                                            "</ul>" +
                                        "</div>" +
                                        "<div class='divider'></div>" +
                                        "<div class='modal-footer2'>" +
                                            "<div class='col-xs-12 bottom text-center'>" +
                                                "<a href='../paginas/AlterarPedido.aspx?str=" + dr["ped_id"] + "'>" +
                                                    "<button type='button' class='btn btn-primary btn-xs'>" +
                                                        " <i class='fa fa-edit'></i> Atualizar" +
                                                    "</button>" +
                                                "</a>" +
                                                "<button type = 'button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalExcluir'>" +
                                                    "<i class='fa fa-trash'></i> Excluir " +
                                                "</button>" +
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
                                                  "<button type='button' class='btn btn-danger' onclick='Excluir(" + dr["ped_id"] + ")'>Sim</button>" +
                                              "</div>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>" +
                                    "</div>");


        }

        string retorno = "";

        foreach(string texto in CockTailSort(fila))
        {
            retorno += texto;
        }

        return retorno;
    }

    protected static List<string> CockTailSort(List<string> lista)
    {
        double[] vetor = new double[lista.Count];
        bool ciclo = false;
        int comeco = 0;
        int fim = vetor.Length - 1;
        string aux = "";
        double aux1 = 0;

        for(int i = 0; i < lista.Count; i++)
        {
            vetor[i] = Numero(lista[i]);
        }

        do
        {
            ciclo = false;
            for (int i = comeco; i < fim; ++i)
            {
                if (vetor[i] > vetor[i + 1])
                {
                    aux = lista[i];
                    aux1 = vetor[i];
                    lista[i] = lista[i + 1];
                    vetor[i] = vetor[i + 1];
                    lista[i + 1] = aux;
                    vetor[i + 1] = aux1;
                    ciclo = true;
                }
            }

            if (!ciclo)
            {
                break;
            }

            ciclo = false;

            --fim;

            for (int i = fim; i > comeco; --i)
            {
                if (vetor[i] < vetor[i - 1])
                {
                    aux = lista[i];
                    aux1 = vetor[i];
                    lista[i] = lista[i - 1];
                    vetor[i] = vetor[i - 1];
                    lista[i - 1] = aux;
                    vetor[i - 1] = aux1;
                    ciclo = true;
                }
            }

            ++comeco;
        } while (ciclo);

        return lista;
    }

    protected static double Numero(string texto)
    {
        string[] texto1 = texto.Split('<');
        string numero = texto1[1];

        Regex r = new Regex("[0-9,.]");
        StringBuilder s = new StringBuilder();
        foreach (Match m in r.Matches(numero))
        {
            s.Append(m.Value);
        }

        string texto2 = s.ToString();
        texto2 = texto2.Replace(".", ",");
        double n = Convert.ToDouble(texto2);
        return n;
    }

    protected void btn_Click(object sender, EventArgs e)
    {
        lbl.Text = CarregarLabelOrdenada();
    }

    [System.Web.Services.WebMethod]
    public static void Excluir(int codigo)
    {
        Pedido ped = new Pedido();

        ped.Ped_id = codigo;

        UsuPedDB.Excluir(ped);
        ItemDB.Excluir(ped);
        PedidoDB.Excluir(ped);
    }
}