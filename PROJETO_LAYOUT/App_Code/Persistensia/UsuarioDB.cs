using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuarioDB
/// </summary>
public class UsuarioDB
{

    /// <summary>
    /// Metodo para selecionar um especifico usuario do banco, passando o codigo dele.
    /// </summary>
    /// <param name="usu_id"></param>
    /// <returns></returns>
    public static Usuario Select(int usu_id)
    {
        Usuario usu = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from usu_usuario where usu_id=?usu_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objReader = objComando.ExecuteReader();

            // Criamos uma variavel que ira amarzenar o valor da chave estrangeira.
            int perfil = 0;
            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                usu = new Usuario();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                usu.Usu_id = Convert.ToInt32(objReader["usu_id"]);
                usu.Usu_nome = Convert.ToString(objReader["usu_nome"]);
                usu.Usu_email = Convert.ToString(objReader["usu_email"]);
                usu.Usu_senha = Convert.ToString(objReader["usu_senha"]);
                perfil = Convert.ToInt32(objReader["per_id"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            // Depois de fecharmos essa conexao, temos que mandar o valor armazenado na variavel para conseguir o valor da outra tabela
            // que tem chave estrangeira.
            usu.Perfil = PerfilDB.Select(perfil);
            return usu;
        }
        catch
        {
            return usu = null;
        }
    }

    /// <summary>
    /// Select All padrão para selecionar todas as informações da tabela
    /// </summary>
    /// <returns></returns>
    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();

            string sql = "select * from usu_usuario;";

            objComando = Mapped.Command(sql, objConexao);
            objDataAdapter = Mapped.Adapter(objComando);
            objDataAdapter.Fill(ds);
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return ds;
        }
        catch
        {
            return ds = null;
        }
    }

    public static int Insert(Usuario usu)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into usu_usuario (usu_nome, usu_email, usu_senha, per_id) values (?usu_nome, ?usu_email, ?usu_senha, ?per_id);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_nome", usu.Usu_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_email", usu.Usu_email));
            objCommand.Parameters.Add(Mapped.Parameter("?usu_senha", usu.Usu_senha));
            objCommand.Parameters.Add(Mapped.Parameter("?per_id", usu.Perfil.Per_id));
            objCommand.ExecuteNonQuery();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            retorno = 0;
        }
        catch (Exception)
        {
            retorno = -2;
        }
        return retorno;
    }

    /// <summary>
    /// Update padrão para atualizar o banco.
    /// </summary>
    /// <param name="usu"></param>
    /// <returns></returns>
    public static int Atualizar(Usuario usu)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update usu_usuario set usu_nome=?nome, usu_email=?email, usu_senha=?senha, per_id=?per_id where usu_id=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", usu.Usu_nome));
            objComando.Parameters.Add(Mapped.Parameter("?email", usu.Usu_email));
            objComando.Parameters.Add(Mapped.Parameter("?senha", usu.Usu_senha));
            objComando.Parameters.Add(Mapped.Parameter("?per_id", usu.Perfil.Per_id));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", usu.Usu_id));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch
        {
            erro = -2;
        }

        return erro;
    }

    /// <summary>
    /// Delete padrão para excluir registros no banco.
    /// </summary>
    /// <param name="usu"></param>
    /// <returns></returns>
    public static int Excluir(Usuario usu)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from usu_usuario where usu_id = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", usu.Usu_id));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch
        {
            erro = -2;
        }

        return erro;
    }

    /// <summary>
    /// Delete para excluir registros do usuario pelo perfil no banco.
    /// </summary>
    /// <param name="per"></param>
    /// <returns></returns>
    public static int Excluir(Perfil per)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from usu_usuario where per_id = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", per.Per_id));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch
        {
            erro = -2;
        }

        return erro;
    }

}