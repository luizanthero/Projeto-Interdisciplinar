using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Produto
/// </summary>
public class Produto
{
    private int pro_id;
    private string pro_nome;
    private double pro_preco;

    public int Pro_id
    {
        get { return pro_id; }
        set { pro_id = value; }
    }


    public string Pro_nome
    {
        get { return pro_nome; }
        set { pro_nome = value; }
    }


    public double Pro_preco
    {
        get { return pro_preco; }
        set { pro_preco = value; }
    }


}