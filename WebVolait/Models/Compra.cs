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

        public string CPFCliente { get; set; }

        public int Cupom { get; set; }

        public int CodTipoPagto { get; set; }

        //        drop procedure if exists spInsertCompra;
        //        DELIMITER $$
        //CREATE PROCEDURE spInsertCompra(vData date, vTotal decimal(15,2), vCpfCompra bigint, vCupom char (6), vTipoPagto int)

        //BEGIN
        //    insert into tb_compra(NotaFiscal, DataCompra, ValorTotal, CPFCompra, Cupom, CodTipoPagto) values(default, vData, vTotal, vCpfCompra, vCupom, vTipoPagto);
        //        END $$

        //CALL spInsertCompra("2022-11-17", null, 52673833846, null, 1);

        //        DELIMITER $$

        //-- Select compra
        //DELIMITER $$
        //CREATE PROCEDURE spSelectCompra(vNotaFiscal int, vData date, vCpfCompra bigint)

        //BEGIN
        //    select NotaFiscal, DataCompra, ValorTotal, CPFCompra, Cupom, CodTipoPagto from tb_compra where NotaFiscal = vNotaFiscal or DataCompra = vData or CPFCompra = vCpfCompra;
        //END $$

        //CALL spSelectCompra(52673833846);

        //        DELIMITER $$

        //-- Alterar valor total compra
        //DELIMITER $$
        //CREATE PROCEDURE spAlterValorCompra(vNotaFiscal int, vTotal decimal(15,2))

        //BEGIN
        //    update tb_compra set ValorTotal = vTotal where NotaFiscal = vNotaFiscal;
        //END $$

        //CALL spAlterValorCompra(1, "1256.00");

        //        DELIMITER $$

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCompra(Compra compra)
        {
            conexao.Open();
            command.CommandText = "call spInsertCompra (@NotaFiscal, @DataCompra, @ValorTotal, @CPFCliente, @Cupom, @CodTipoPagto);";
            command.Parameters.Add("@NotaFiscal", MySqlDbType.Int16).Value = compra.NotaFiscal;
            command.Parameters.Add("@DataCompra", MySqlDbType.Date).Value = compra.DataCompra;
            command.Parameters.Add("@ValorTotal", MySqlDbType.Decimal).Value = compra.ValorTotal;
            command.Parameters.Add("@CPFCliente", MySqlDbType.Int64).Value = compra.CPFCliente;
            command.Parameters.Add("@Cupom", MySqlDbType.Int16).Value = compra.Cupom;
            command.Parameters.Add("@CodTipoPagto", MySqlDbType.Int16).Value = compra.CodTipoPagto;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public void UpdateCompra(Compra compra)
        {
            conexao.Open();
            var updateQuery = "";
            updateQuery += "call spAlterValorCompra ";
            updateQuery += string.Format("({0}, {1})",
                compra.NotaFiscal,                   //0 ''
                compra.ValorTotal);                  //1 ''

            command.Connection = conexao;
            command.CommandText = updateQuery;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public Compra SelectCompra(int notaFiscal, DateTime date, string cpfcliente)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectCompra(@vNotaFiscal, @vData, @vCpfCompra);"; //vNotaFiscal int, vData date, vCpfCompra bigint)
            command.Parameters.Add("@LoginCliente", MySqlDbType.Int32).Value = notaFiscal;
            command.Parameters.Add("@LoginCliente", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@LoginCliente", MySqlDbType.Int64).Value = cpfcliente;
            command.Connection = conexao;

            var reader = command.ExecuteReader();

            var tempCompra = new Compra();

            if (reader.Read())
            {
                tempCompra.NotaFiscal = int.Parse(reader["NotaFiscal"].ToString());
                tempCompra.DataCompra = DateTime.Parse(reader["DataCompra"].ToString());
                tempCompra.ValorTotal = decimal.Parse(reader["ValorTotal"].ToString());
                tempCompra.CPFCliente = reader["CPFCliente"].ToString();
                tempCompra.Cupom = int.Parse(reader["Cupom"].ToString());
                tempCompra.CodTipoPagto = int.Parse(reader["CodTipoPagto"].ToString());
            };

            reader.Close();
            conexao.Close();

            return tempCompra;
        }
    }
}