using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProdutoDB
/// </summary>
public class ProdutoDB
{

    /// <summary>
    /// Metodo para selecionar um especifico produto do banco, passando o codigo dele.
    /// </summary>
    /// <param name="pro_id"></param>
    /// <returns></returns>
    public static Produto Select(int pro_id)
    {
        Produto pro = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from pro_produto where pro_id=?pro_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?pro_id", pro_id));
            objReader = objComando.ExecuteReader();

            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                pro = new Produto();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                pro.Pro_id = Convert.ToInt32(objReader["pro_id"]);
                pro.Pro_nome = Convert.ToString(objReader["pro_nome"]);
                pro.Pro_preco = Convert.ToDouble(objReader["pro_preco"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            return pro;
        }
        catch
        {
            return pro = null;
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

            string sql = "select * from pro_produto;";

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
    /// <param name="pro"></param>
    /// <returns></returns>
    public static int Insert(Produto pro)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into pro_produto (pro_nome, pro_preco) values (?pro_nome, ?pro_preco);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pro_nome", pro.Pro_nome));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_preco", pro.Pro_preco));
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
    /// <param name="pro"></param>
    /// <returns></returns>
    public static int Atualizar(Produto pro)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update pro_produto set pro_nome=?nome, pro_preco=?preco where pro_id=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?nome", pro.Pro_nome));
            objComando.Parameters.Add(Mapped.Parameter("?preco", pro.Pro_preco));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", pro.Pro_id));
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
    /// <param name="pro"></param>
    /// <returns></returns>
    public static int Excluir(Produto pro)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from pro_produto where pro_id = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", pro.Pro_id));
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