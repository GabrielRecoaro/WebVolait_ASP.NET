using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(9)]
        public string CPFCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomeCliente { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50)]
        public string NomeSocialCliente { get; set; }

        [Display(Name = "E-mail")]
        [Remote ("SelectLogin","AutenticacaoCliente", ErrorMessage ="O login já existe!")]
        public string EmailCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(11)]
        [Display(Name = "Número de Telefone")]
        public string TelefoneCliente { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaCliente { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCliente(Cliente cliente)
        {
            conexao.Open();
            command.CommandText = "call spInsertCli (@CPFCliente, @NomeCliente, @NomeSocialCliente, @EmailCliente, @TelefoneCliente, @SenhaCliente);";
            command.Parameters.Add("@CPFCliente", MySqlDbType.VarChar).Value = cliente.CPFCliente;
            command.Parameters.Add("@NomeCliente", MySqlDbType.VarChar).Value = cliente.NomeCliente;
            command.Parameters.Add("@NomeSocialCliente", MySqlDbType.VarChar).Value = cliente.NomeSocialCliente;
            command.Parameters.Add("@EmailCliente", MySqlDbType.VarChar).Value = cliente.EmailCliente;
            command.Parameters.Add("@TelefoneCliente", MySqlDbType.VarChar).Value = cliente.TelefoneCliente;
            command.Parameters.Add("@SenhaCliente", MySqlDbType.VarChar).Value = cliente.SenhaCliente;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public string SelectLogin(string vEmailCliente)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectLogin(@EmailCliente);";
            command.Parameters.Add("@EmailCliente", MySqlDbType.VarChar).Value = vEmailCliente;
            command.Connection = conexao;
            string EmailCliente = (string)command.ExecuteScalar(); // ExecuteScalar: RETORNAR APENAS 1 VALOR
            conexao.Close();

            if (EmailCliente == null)
                EmailCliente = "";
            return EmailCliente;
        }


    }
}