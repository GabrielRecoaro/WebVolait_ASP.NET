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
        [Display(Name = "CPF do Cliente")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(9)]
        public string CPFCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome Completo", AutoGenerateFilter = false)]
        public string NomeCliente { get; set; }
    
        [Display(Name = "Nome Social (caso tenha)")]
        [MaxLength(50)]
        public string NomeSocialCliente { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [Display(Name = "E-mail")]
        [Remote ("SelectLogin","AutenticacaoCliente", ErrorMessage ="O login já existe!")]
        public string LoginCliente { get; set; }

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
            command.CommandText = "call spInsertCli (@CPFCliente, @NomeCliente, @NomeSocialCliente, @LoginCliente, @TelefoneCliente, @SenhaCliente);";
            command.Parameters.Add("@CPFCliente", MySqlDbType.VarChar).Value = cliente.CPFCliente;
            command.Parameters.Add("@NomeCliente", MySqlDbType.VarChar).Value = cliente.NomeCliente;
            command.Parameters.Add("@NomeSocialCliente", MySqlDbType.VarChar).Value = cliente.NomeSocialCliente;
            command.Parameters.Add("@LoginCliente", MySqlDbType.VarChar).Value = cliente.LoginCliente;
            command.Parameters.Add("@TelefoneCliente", MySqlDbType.VarChar).Value = cliente.TelefoneCliente;
            command.Parameters.Add("@SenhaCliente", MySqlDbType.VarChar).Value = cliente.SenhaCliente;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public string SelectLogin(string vLoginCliente)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectLoginCli(@LoginCliente);";
            command.Parameters.Add("@LoginCliente", MySqlDbType.VarChar).Value = vLoginCliente;
            command.Connection = conexao;
            string LoginCliente = (string)command.ExecuteScalar(); 
            conexao.Close();

            if (LoginCliente == null)
                LoginCliente = "";
            return LoginCliente;
        }

        public Cliente SelectCliente(string vLoginCliente)
        {
            conexao.Open();
                command.CommandText = "CALL spSelectCli(@LoginCliente);";
                command.Parameters.Add("@LoginCliente", MySqlDbType.VarChar).Value = vLoginCliente;
                command.Connection = conexao;
            var readCliente = command.ExecuteReader();
            var tempCliente = new Cliente();

            if (readCliente.Read())
            {
                tempCliente.CPFCliente = (readCliente["CPFCliente"].ToString());
                tempCliente.NomeCliente = readCliente["NomeCliente"].ToString();
                tempCliente.NomeSocialCliente = readCliente["NomeSocialCliente"].ToString();
                tempCliente.LoginCliente = readCliente["LoginCliente"].ToString();
                tempCliente.TelefoneCliente = readCliente["TelefoneCliente"].ToString();
                tempCliente.SenhaCliente = readCliente["SenhaCliente"].ToString();
            };

            readCliente.Close();
            conexao.Close();

            return tempCliente;
        }

        public void UpdateSenha(Cliente cliente)
        {
            conexao.Open();
            command.CommandText = "CALL spAlterSenhaCli(@LoginCliente, @SenhaCliente);";
            command.Parameters.Add("@LoginCliente", MySqlDbType.VarChar).Value = cliente.LoginCliente;
            command.Parameters.Add("@SenhaCliente", MySqlDbType.VarChar).Value = cliente.SenhaCliente;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public void UpdateCliente(Cliente cliente)
        {
            conexao.Open();
            var updateQuery = "";
            updateQuery += "call spAlterCli ";
            updateQuery += string.Format("({0}, '{1}', '{2}', '{3}', '{4}', '{5}')",
                cliente.CPFCliente,                    //0 
                cliente.NomeCliente,                   //1 ''
                cliente.NomeSocialCliente,             //2 ''
                cliente.LoginCliente,                  //3 ''
                cliente.TelefoneCliente,               //4 ''
                cliente.SenhaCliente);                 //5 ''

            command.Connection = conexao;
            command.CommandText = updateQuery;
            command.ExecuteNonQuery();
            conexao.Close();
        }


        public void DeleteCliente(Cliente cliente)
        {
            conexao.Open();
            var deleteQuery = "";
            deleteQuery += string.Format("call spDeleteCli({0})", cliente.CPFCliente);

            command.Connection = conexao;
            command.CommandText = deleteQuery;
            command.ExecuteNonQuery();
            conexao.Close();

        }
    }
}
