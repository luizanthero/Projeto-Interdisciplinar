using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PedidoDB
/// </summary>
public class PedidoDB
{

    /// <summary>
    /// Metodo para selecionar um especifico pedido do banco, passando o codigo dele.
    /// </summary>
    /// <param name="ped_id"></param>
    /// <returns></returns>
    public static Pedido Select(int ped_id)
    {
        Pedido ped = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from ped_pedido where ped_id=?ped_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?ped_id", ped_id));
            objReader = objComando.ExecuteReader();

            // Criamos uma variavel que ira amarzenar o valor da chave estrangeira.
            int produto = 0;
            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                ped = new Pedido();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                ped.Ped_id = Convert.ToInt32(objReader["ped_id"]);
                ped.Ped_frete = Convert.ToDouble(objReader["ped_frete"]);
                ped.Ped_status = Convert.ToString(objReader["ped_status"]);
                produto = Convert.ToInt32(objReader["pro_id"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            // Depois de fecharmos essa conexao, temos que mandar o valor armazenado na variavel para conseguir o valor da outra tabela
            // que tem chave estrangeira.
            ped.Produto = ProdutoDB.Select(produto);
            return ped;
        }
        catch
        {
            return ped = null;
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

            string sql = "select * from ped_pedido;";

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
    /// Insert padrão para inserir no banco.
    /// </summary>
    /// <param name="ped"></param>
    /// <returns></returns>
    public static int Insert(Pedido ped)
    {
        int retorno = 0; // Retornar Id de pedido = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into ped_pedido (ped_frete, ped_status, pro_id) values (?ped_frete, ?ped_status, ?pro_id);" +
                "select last_insert_id() as id";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?ped_frete", ped.Ped_frete));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_status", ped.Ped_status));
            objCommand.Parameters.Add(Mapped.Parameter("?pro_id", ped.Produto.Pro_id));
            // Armazendo o Id do pedido, que é auto incremment
            retorno = Convert.ToInt32(objCommand.ExecuteScalar());
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
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
    /// <param name="ped"></param>
    /// <returns></returns>
    public static int Atualizar(Pedido ped)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "update ped_pedido set ped_status=?status where ped_id=?codigo;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?status", ped.Ped_status));
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

    /// <summary>
    /// Delete padrão para excluir registros no banco.
    /// </summary>
    /// <param name="ped"></param>
    /// <returns></returns>
    public static int Excluir(Pedido ped)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            objConexao = Mapped.Connection();

            string sql = "delete from ped_pedido where ped_id=?codigo;";

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

    /// <summary>
    /// Delete para excluir pedido pelo produto no banco.
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

            string sql = "delete from ped_pedido where pro_id = ?codigo;";

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