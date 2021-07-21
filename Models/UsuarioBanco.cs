
using MySqlConnector;

namespace tcc_ihosana.Models
{
    public class UsuarioBanco
    {
        private const string dadosconexao = "Database=projetointegrado; Data Source=localhost; User Id=root";

        public void Insert(Usuario novo)
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string Sql = "INSERT INTO login (Nome, Login ,Senha, TipoUS ) values (@Nome, @Login ,@Senha, @TipoUS )";

            MySqlCommand comando = new MySqlCommand(Sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novo.Nome);
            comando.Parameters.AddWithValue("@Login", novo.Login);
            comando.Parameters.AddWithValue("@Senha", novo.Senha);
            comando.Parameters.AddWithValue("@TipoUS", novo.TipoUS);
            comando.ExecuteNonQuery();

            conexao.Close();
        }
      
        public Usuario QueryLogin(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string sql = "SELECT * FROM login WHERE Login = @Login AND @TipoUS =@TipoUS";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@Login", u.Login);
            comandoQuery.Parameters.AddWithValue("@Senha", u.Senha);
            comandoQuery.Parameters.AddWithValue("@TipoUS", u.TipoUS);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if (reader.Read())
            {
                usr = new Usuario();
                usr.Id = reader.GetInt32("Id");
                 if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
            usr.Nome = reader.GetString("Nome");

                if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                    usr.Login = reader.GetString("Login");

                if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
                    usr.Senha = reader.GetString("Senha");
                      if (!reader.IsDBNull(reader.GetOrdinal("TipoUS")))
                    usr.TipoUS = reader.GetInt32("TipoUS");
            }

            conexao.Close();
            return usr;
        } 
        
    }
}