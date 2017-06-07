using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PerfilDB
/// </summary>
public class PerfilDB
{

    /// <summary>
    /// Metodo para selecionar um especifico perfil do banco, passando o codigo dele.
    /// </summary>
    /// <param name="per_id"></param>
    /// <returns></returns>
    public static Perfil Select(int per_id)
    {
        Perfil per = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from per_perfil where per_id=?per_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?per_id", per_id));
            objReader = objComando.ExecuteReader();

            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                per = new Perfil();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                per.Per_id = Convert.ToInt32(objReader["per_id"]);
                per.Per_tipo = Convert.ToString(objReader["per_tipo"]);

            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return per;
        }
        catch
        {
            return per = null;
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

            string sql = "select * from per_perfil;";

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

    /// <summary>
    /// Insert padrão para inserir no banco
    /// </summary>
    /// <param name="per"></param>
    /// <returns></returns>
    public static int Insert(Perfil per)
    {
        int retorno = 0; // Retornar Id de perfil = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into per_perfil (per_tipo) values (?per_tipo);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?per_tipo", per.Per_tipo));
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
    /// <param name="per"></param>
    /// <returns></returns>
    public static int Atualizar(Perfil per)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update per_perfil set per_tipo=?tipo where per_id=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?tipo", per.Per_tipo));
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

    /// <summary>
    /// Delete padrão para excluir registros no banco.
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

            string sql = "delete from per_perfil where per_id = ?codigo;";

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