using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebVolait.Repositorio;
using System.ComponentModel.DataAnnotations;

namespace WebVolait.Models
{
    public class Cupom
    {
        [Display(Name = "Id do cupom")]
        public int CupomId { get; set; }

        [Display(Name = "Código do cupom")]
        public string Cupomcode { get; set; }

        [Display(Name = "Código do cupom")]
        public decimal Valordesconto { get; set; }

        [Display(Name = "Data de validade do cupom")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime Cupomvalidade { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCupom(Cupom cupom)
        {
            conexao.Open();
            command.CommandText = "call spInsertCupom (@Cupomcode, @Valordesconto, @Cupomvalidade);";
            command.Parameters.Add("@Cupomcode", MySqlDbType.VarChar).Value = cupom.Cupomcode;
            command.Parameters.Add("@Valordesconto", MySqlDbType.Decimal).Value = cupom.Valordesconto;
            command.Parameters.Add("@Cupomvalidade", MySqlDbType.Date).Value = cupom.Cupomvalidade;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }


        public void UpdateCupom(Cupom cupom)
        {
            conexao.Open();
            command.CommandText = "call spAlterCupom (@CupomId, @Cupomcode, @Valordesconto, @Cupomvalidade);";
            command.Parameters.Add("@CupomId", MySqlDbType.VarChar).Value = cupom.CupomId;
            command.Parameters.Add("@Cupomcode", MySqlDbType.VarChar).Value = cupom.Cupomcode;
            command.Parameters.Add("@Valordesconto", MySqlDbType.Decimal).Value = cupom.Valordesconto;
            command.Parameters.Add("@Cupomvalidade", MySqlDbType.Date).Value = cupom.Cupomvalidade;

            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }


        public void DeleteCupom(Cupom cupom)
        {
            conexao.Open();
            var deleteQuery = "";
            deleteQuery += string.Format("call spDeleteCupom({0})", cupom.CupomId);

            command.Connection = conexao;
            command.CommandText = deleteQuery;
            command.ExecuteNonQuery();
            conexao.Close();

        }
    }

}
