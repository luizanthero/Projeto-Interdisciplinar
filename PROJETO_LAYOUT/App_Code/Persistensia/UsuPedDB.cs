using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UsuPedDB
/// </summary>
public class UsuPedDB
{

    /// <summary>
    /// Metodo para selecionar um especifico usuario com pedido do banco, passando o codigo dele.
    /// </summary>
    /// <param name="usu_id"></param>
    /// <returns></returns>
    public static UsuPed Select(int usu_id)
    {
        UsuPed upd = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from usu_ped where usu_id=?usu_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
            objReader = objComando.ExecuteReader();

            // Criamos uma variavel que ira amarzenar o valor da chave estrangeira.
            int usuario = 0, pedido = 0;
            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                upd = new UsuPed();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                usuario = Convert.ToInt32(objReader["usu_id"]);
                pedido = Convert.ToInt32(objReader["ped_id"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            // Depois de fecharmos essa conexao, temos que mandar o valor armazenado na variavel para conseguir o valor da outra tabela
            // que tem chave estrangeira.
            upd.Usuario = UsuarioDB.Select(usuario);
            upd.Pedido = PedidoDB.Select(pedido);
            return upd;
        }
        catch
        {
            return upd = null;
        }
    }

    /// <summary>
    /// Metodo para selecionar um especifico usuario com pedido do banco, passando o codigo dele.
    /// </summary>
    /// <param name="ped_id"></param>
    /// <returns></returns>
    public static UsuPed SelectUsu(int ped_id)
    {
        UsuPed upd = null;
        try
        {
            //Instanciando as conexoes com o banco (padrão)
            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objReader;
            objConexao = Mapped.Connection();

            string sql = "select * from usu_ped where ped_id=?ped_id;";

            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?ped_id", ped_id));
            objReader = objComando.ExecuteReader();

            // Criamos uma variavel que ira amarzenar o valor da chave estrangeira.
            int usuario = 0, pedido = 0;
            //Este while serve para enquanto tiver registros no banco, ele ira amarzenar dentro do Objeto Item, no caso uma fez só.
            while (objReader.Read()) //Este Objeto Reader que é o responsavel por ler o conteudo das tabelas do banco.
            {
                upd = new UsuPed();
                //Salvando na variavel do Objeto Item a informação que encontrou naquele campo.
                usuario = Convert.ToInt32(objReader["usu_id"]);
                pedido = Convert.ToInt32(objReader["ped_id"]);
            }

            //Encerra conexao com o banco.
            objConexao.Close();
            objComando.Dispose();
            objConexao.Dispose();
            // Depois de fecharmos essa conexao, temos que mandar o valor armazenado na variavel para conseguir o valor da outra tabela
            // que tem chave estrangeira.
            upd.Usuario = UsuarioDB.Select(usuario);
            upd.Pedido = PedidoDB.Select(pedido);
            return upd;
        }
        catch
        {
            return upd = null;
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

            string sql = "select * from usu_ped;";

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
    /// <param name="usu_id"></param>
    /// <param name="ped_id"></param>
    /// <returns></returns>
    public static int Insert(int usu_id, int ped_id)
    {
        int retorno = 0; // 0 = OK / -2 = Erro

        try
        {
            IDbConnection objConexao;
            IDbCommand objCommand;

            string sql = "insert into usu_ped (usu_id, ped_id) values (?usu_id, ?ped_id);";

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
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
    /// Delete para excluir a referencia apartir do pedido.
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

            string sql = "delete from usu_ped where ped_id = ?codigo;";

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
    /// Delete para excluir a referencia apartir do usuario.
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

            string sql = "delete from usu_ped where usu_id = ?codigo;";

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

}
