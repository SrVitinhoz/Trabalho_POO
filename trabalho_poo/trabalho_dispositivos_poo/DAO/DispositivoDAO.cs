using MySql.Data.MySqlClient;
using trabalho_dispositivos_poo.Models;

namespace trabalho_dispositivos_poo.DAO
{
    internal class DispositivoDAO
    {
        public void Incert(Dispositivos dis)
        {
            try
            {
                string sql = "INSERT INTO dispositivos(aliquota, descricao, status_dispositivo) VALUES (@aliquota, @descricao, @status_dispositivo)";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@aliquota", dis.aliquota);
                comando.Parameters.AddWithValue("@descricao", dis.descricao);
                comando.Parameters.AddWithValue("@status_dispositivo", dis.status_dispositivo);
                comando.ExecuteNonQuery();
                Console.WriteLine("Dispositivo cadastrado com sucesso!!");
                /* Conect.FecharConexao();*/
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar o aluno! {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Delete(Dispositivos dis)
        {
            try
            {
                string sql = "DELETE FROM dispositivo WHERE id = @id";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", dis.Id);
                comando.ExecuteNonQuery();
                Console.WriteLine("Cliente excluido com sucesso");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir o cliente{ex.Message}");
            }
        }

        public List<Dispositivos> list()
        {
            List<Dispositivos> dis = new List<Dispositivos>();
            try
            {
                var sql = "SELECT * FROM dispositivo ORDER BY aliquota";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dispositivos disp = new Dispositivos();
                        disp.Id = dr.GetInt32("Id");
                        disp.aliquota = dr.GetFloat("aliquota");
                        disp.descricao = dr.GetString("descricao");
                        disp.status_dispositivo = dr.GetString("status_dispositivo");

                        {
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                            Console.WriteLine($"ID: {disp.Id} " +
                                $"ALIQUOTA: {disp.aliquota} " +
                                $"DESCRICAO: {disp.descricao} " +
                                $"STATUS: {disp.status_dispositivo}");
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                        }
                    }
                }
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro aos listar os Dispositivos! {ex.Message}");
            }
            return dis;
        }

        public void Update(Dispositivos dis)
        {
            try
            {
                string sql = "UPDATE Dispositivos SET aliquota = @aliquota, descricao = @descricao, status_dispositivo = @status_dispositivos WHERE Id = @Id";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@aliquota", dis.aliquota);
                comando.Parameters.AddWithValue("@descricao", dis.descricao);
                comando.Parameters.AddWithValue("@status_dispositivo", dis.status_dispositivo);
                comando.Parameters.AddWithValue("@Id", dis.Id);
                comando.ExecuteNonQuery();
                Console.WriteLine("Dispositivo Atualizado com sucesso!!");
                /* Conect.FecharConexao();*/
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar o dispositivo! {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }
    }
}
