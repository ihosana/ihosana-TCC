
using System.Collections.Generic;
using MySqlConnector;

namespace tcc_ihosana.Models
{
    public class Agendarbanco
    {

        private const string dadosliga = "Database=projetointegrado; Data Source=localhost; User Id=root";

        public void Insert(Agendamento agendar, int a)
        {
            MySqlConnection liga = new MySqlConnection(dadosliga);
            liga.Open();
            string Sql = "INSERT INTO Consulta (NomeCompleto, Marcar ,Tipo, Turno, Idade ) values (@NomeCompleto, @Marcar ,@Tipo, @Turno, @Idade )";

            MySqlCommand comando = new MySqlCommand(Sql, liga);
            comando.Parameters.AddWithValue("@NomeCompleto", agendar.NomeCompleto);
            comando.Parameters.AddWithValue("@Marcar", agendar.Marcar);
            comando.Parameters.AddWithValue("@Tipo", agendar.Tipo);
            comando.Parameters.AddWithValue("@Turno", agendar.Turno);
            comando.Parameters.AddWithValue("@Idade", agendar.Idade);
            comando.ExecuteNonQuery();

            liga.Close();
        }
 
        public List<Agendamento> Query()
        {
            MySqlConnection liga = new MySqlConnection(dadosliga);
            liga.Open();
            string sql = "SELECT * FROM consulta ORDER BY Marcar";
            MySqlCommand comandoQuery = new MySqlCommand(sql, liga);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Agendamento> lista = new List<Agendamento>();
            while (reader.Read())
            {
                Agendamento aqui = new Agendamento();
                aqui.Idconsulta = reader.GetInt32("idconsulta");

                if (!reader.IsDBNull(reader.GetOrdinal("NomeCompleto")))
                    aqui.NomeCompleto = reader.GetString("NomeCompleto");

                if (!reader.IsDBNull(reader.GetOrdinal("Marcar")))
                    aqui.Marcar = reader.GetDateTime("Marcar");
                lista.Add(aqui);
                   if (!reader.IsDBNull(reader.GetOrdinal("Turno")))
                    aqui.Turno = reader.GetString("Turno");
            }
            liga.Close();
            return lista;
        }
        
    }


}