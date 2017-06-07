using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuPed
/// </summary>
public class UsuPed
{
    private Usuario _usuario;
    private Pedido _pedido;

    /// <summary>
    /// Cria uma instancia de Usuario em UsuPed.
    /// </summary>
    public Usuario Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    /// <summary>
    /// Cria uma instancia de Pedido em UsuPed.
    /// </summary>
    public Pedido Pedido
    {
        get { return _pedido; }
        set { _pedido = value; }
    }

}