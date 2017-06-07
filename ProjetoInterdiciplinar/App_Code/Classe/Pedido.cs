using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pedido
/// </summary>
public class Pedido
{
    private int ped_id;
    private string ped_status;
    private double? ped_frete;
    // chaves estrangeiras
    private Produto _produto;

    /// <summary>
    /// Cria uma instancia de Produto em Pedido.
    /// </summary>
    public Produto Produto
    {
        get { return _produto; }
        set { _produto = value; }
    }

    public double? Ped_frete
    {
        get { return ped_frete; }
        set { ped_frete = value; }
    }

    public string Ped_status
    {
        get { return ped_status; }
        set { ped_status = value; }
    }

    public int Ped_id
    {
        get { return ped_id; }
        set { ped_id = value; }
    }
   

   

}