using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
    private int usu_id;
    private string usu_nome;
    private string usu_email;
    private string usu_senha;
    // Atençao para a chave estranjeira
    private Perfil _perfil;

    /// <summary>
    /// Cria uma instancia do objeto Perfil dentro de Usuario.
    /// </summary>
    public Perfil Perfil
    {
        get { return _perfil; }
        set { _perfil = value; }
    }

    public string Usu_senha
    {
        get { return usu_senha; }
        set { usu_senha = value; }
    }

    public string Usu_email
    {
        get { return usu_email; }
        set { usu_email = value; }
    }

    public string Usu_nome
    {
        get { return usu_nome; }
        set { usu_nome = value; }
    }

    public int Usu_id
    {
        get { return usu_id; }
        set { usu_id = value; }
    }
}

