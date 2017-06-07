using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemDB
/// </summary>
public class ItemDB
{
    
    /// <summary>
    /// Metodo para selecionar um especifico item do banco, passando o codigo dele.
    /// </summary>
    /// <param name="ite_id"></param>
    /// <returns></returns>
    public static Item Select(int ped_id)
    {
        Item ite = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from ite_item where ped_id=?ped_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?ped_id", ped_id));
            objReader = objComando.ExecuteReader();
            
            // Criamos uma variavel que ira amarzenar o valor da chave estrangeira.
            int pedido = 0;
            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                ite = new Item();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                ite.Ite_id = Convert.ToInt32(objReader["ite_id"]);
                ite.Ite_quantidade = Convert.ToInt32(objReader["ite_quantidade"]);
                pedido = Convert.ToInt32(objReader["ped_id"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            // Depois de fecharmos essa conexao, temos que mandar o valor armazenado na variavel para conseguir o valor da outra tabela
            // que tem chave estrangeira.
            ite.Pedido = PedidoDB.Select(pedido);
            return ite;
        }
        catch
        {
            return ite = null;
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

            string sql = "select * from ite_item;";

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
    /// <param name="ite"></param>
    /// <returns></returns>
    public static int Insert(Item ite, int ped_id)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into ite_item (ite_quantidade, ped_id) values (?ite_quantidade, ?ped_id);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ite_quantidade", ite.Ite_quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_id", ped_id));
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
    /// <param name="ite"></param>
    /// <returns></returns>
    public static int Atualizar(Item ite, int ped_id)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update ite_item set ite_quantidade=?quantidade where ped_id=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?quantidade", ite.Ite_quantidade));
            objComando.Parameters.Add(Mapped.Parameter("?codigo", ped_id));
            objComando.ExecuteNonQuery();
            objComando.Dispose();
            objConexao.Dispose();
            objConexao.Close();
        }
        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }

    /// <summary>
    /// Delete padrão para excluir registros no banco.
    /// </summary>
    /// <param name="ite"></param>
    /// <returns></returns>
    public static int Excluir(Pedido ped)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from ite_item where ped_id = ?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?codigo", ped.Ped_id));
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