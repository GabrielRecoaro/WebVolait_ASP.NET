using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebVolait.Repositorio;

namespace WebVolait.Models
{
    public class Cupom
    {
        public int CupomId { get; set; }

        public string Cupomcode { get; set; }

        public decimal Valordesconto { get; set; }

        public DateTime Cupomvalidade { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCupom(Cupom cupom)
        {
            conexao.Open();
            command.CommandText = "call spInsertCupom (@CupomId, @Cupomcode, @Valordesconto, @Cupomvalidade);";
            command.Parameters.Add("@CupomId", MySqlDbType.Int16).Value = cupom.CupomId;
            command.Parameters.Add("@Cupomcode", MySqlDbType.VarChar).Value = cupom.Cupomcode;
            command.Parameters.Add("@Valordesconto", MySqlDbType.Decimal).Value = cupom.Valordesconto;
            command.Parameters.Add("@Cupomvalidade", MySqlDbType.DateTime).Value = cupom.Cupomvalidade;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }
    }

}