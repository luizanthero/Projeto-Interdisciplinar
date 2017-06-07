using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Item
/// </summary>
public class Item
{
    private int ite_id;
    private int ite_quantidade;
    private Pedido _pedido;

    /// <summary>
    /// Cria uma instancia de Pedido em Item.
    /// </summary>
    public Pedido Pedido
    {
        get { return _pedido; }
        set { _pedido = value; }
    }

    public int Ite_quantidade
    {
        get { return ite_quantidade; }
        set { ite_quantidade = value; }
    }

    public int Ite_id
    {
        get { return ite_id; }
        set { ite_id = value; }
    }
    
}