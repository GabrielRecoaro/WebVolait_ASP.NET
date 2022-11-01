using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebVolait.Models
{
    public class Cliente
    {
        public int CPFCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomeCliente { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50)]
        public string NomeSocialCliente { get; set; }

        [Display(Name = "E-mail")]
        public string EmailCliente { get; set; }

        [Display(Name = "Número de Telefone")]
        public string TelefoneCliente { get; set; }

        [Display(Name = "Endereço")]
        public string EnderecoCliente { get; set; }

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
            command.CommandText = "call spInsertCli (@CPFCliente, @NomeCliente, @NomeSocialCliente, @NomeCliente, @EmailCliente, @TelefoneCliente, @SenhaCliente);";
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

        public string SelectLogin(string vLogin)
        {
            conexao.Open();
            command.CommandText = "call spSelectLogin (@LoginCliente);";
            command.Parameters.Add("@LoginCliente", MySqlDbType.String).Value = vLogin;
            command.Connection = conexao;

            string Login = (string)command.ExecuteScalar();
            conexao.Close();
            if (Login == null)
                Login = "";

            return Login;
        }
    }
}