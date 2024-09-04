using MySql.Data.MySqlClient;

public static class Conexao
{
    static MySqlConnection conexao;// objeto responsável por controlar a conexão com a base 

    public static MySqlConnection Conectar()
    {
        try
        {
            string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=gestao_vendas";
            conexao = new MySqlConnection(strconexao);
            conexao.Open();
            Console.WriteLine("Conexão realizada com sucesso!!");
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao Conectar" + ex.Message);
        }
        return conexao;
    }

    public static void FecharConexao()
    {
        conexao.Clone();
    }
}
