using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebVolait.Repositorio;

namespace WebVolait.Models
{
    public class Compra
    {
        public int NotaFiscal { get; set; }

        public DateTime DataCompra { get; set; }

        public decimal ValorTotal { get; set; }

        public long CPFCliente { get; set; }

        public string Cupom { get; set; }

        public string CodTipoPagto { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public Compra SelectCompra(int vNotaFiscal)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectCompra(@vNotaFiscal, @vData, @vCpfCliente);";
            command.Parameters.Add("@NotaFiscal", MySqlDbType.Int32).Value = vNotaFiscal;
            command.Connection = conexao;

            var reader = command.ExecuteReader();

            var tempCompra = new Compra();

            if (reader.Read())
            {
                tempCompra.NotaFiscal = int.Parse(reader["NotaFiscal"].ToString());
                tempCompra.DataCompra = DateTime.Parse(reader["DataCompra"].ToString());
                tempCompra.ValorTotal = decimal.Parse(reader["ValorTotal"].ToString());
                tempCompra.CPFCliente = Int64.Parse(reader["CPFCliente"].ToString());
                tempCompra.Cupom = (reader["Cupom"].ToString());
                tempCompra.CodTipoPagto = (reader["CodTipoPagto"].ToString());
            };

            reader.Close();
            conexao.Close();

            return tempCompra;
        }


        public void InsertCompra(Compra compra)
        {
            conexao.Open();
            command.CommandText = "call spInsertCompra (@DataCompra, @ValorTotal, @CPFCliente, @Cupom, @CodTipoPagto);";
            command.Parameters.Add("@DataCompra", MySqlDbType.Date).Value = compra.DataCompra;
            command.Parameters.Add("@ValorTotal", MySqlDbType.Decimal).Value = compra.ValorTotal;
            command.Parameters.Add("@CPFCliente", MySqlDbType.Int64).Value = compra.CPFCliente;
            command.Parameters.Add("@Cupom", MySqlDbType.VarChar).Value = compra.Cupom;
            command.Parameters.Add("@CodTipoPagto", MySqlDbType.VarChar).Value = compra.CodTipoPagto;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public void UpdateCompra(Compra compra)
        {
            conexao.Open();
            command.CommandText = "call spAlterValorCompra (@NotaFiscal, @ValorTotal);";
            command.Parameters.Add("@NotFiscal", MySqlDbType.VarChar).Value = compra.NotaFiscal;
            command.Parameters.Add("@ValorTotal", MySqlDbType.VarChar).Value = compra.ValorTotal;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();

        }

    }
}