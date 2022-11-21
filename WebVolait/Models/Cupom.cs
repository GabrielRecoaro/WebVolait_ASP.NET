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
        public string IdCupom { get; set; }

        public string DescCupom { get; set; }

        public decimal ValorCupom { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCupom(Cupom cupom)
        {
            conexao.Open();
            command.CommandText = "call spInsertCupom (@Cupom, @DescCupom, @ValorCupom);";
            command.Parameters.Add("@Cupom", MySqlDbType.VarChar).Value = cupom.IdCupom;
            command.Parameters.Add("@DesCupom", MySqlDbType.VarChar).Value = cupom.DescCupom;
            command.Parameters.Add("@ValorCupom", MySqlDbType.Decimal).Value = cupom.ValorCupom;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }
    }

    
    //    DELIMITER $$
    //CREATE PROCEDURE spInsertCupom(vCupom char(6), vDescCupom varchar(100), vValor decimal (15,2))

    //BEGIN
    //    insert into tb_cupom(Cupom, DescCupom, ValorDesconto) values(vCupom, vDescCupom, vValor);
    //    END $$
}