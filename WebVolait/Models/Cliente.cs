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

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(50)]
        public string LoginCliente { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaCliente { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmaSenhaCliente { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertCliente(Cliente cliente)
        {
            conexao.Open();
            command.CommandText = "call spInsertCliente (@NomeCliente, @LoginCliente, @SenhaCliente);";
            command.Parameters.Add("@NomeCliente", MySqlDbType.VarChar).Value = cliente.NomeCliente;
            command.Parameters.Add("@LoginCliente", MySqlDbType.VarChar).Value = cliente.LoginCliente;
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