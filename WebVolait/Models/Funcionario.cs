using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WebVolait.Repositorio;

namespace WebVolait.Models
{
    public class Funcionario
    {
        [Display(Name = "CPF do Funcionário")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string CPFFuncionario { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome Completo", AutoGenerateFilter = false)]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Nome Social (caso tenha)")]
        [MaxLength(50)]
        public string NomeSocialFuncionario { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string LoginFuncionario { get; set; }

        [Display(Name = "Número de Telefone")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(15, ErrorMessage = "Caracteres a mais")]
        public string TelefoneFuncionario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaFuncionario { get; set; }


        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertFuncionario(Funcionario funcionario)
        {
            conexao.Open();
            command.CommandText = "call spInsertFunc (@CPFFuncionario, @NomeFuncionario, @NomeSocialFuncionario, @LoginFuncionario, @TelefoneFuncionario, @SenhaFuncionario);";
            command.Parameters.Add("@CPFFuncionario", MySqlDbType.VarChar).Value = funcionario.CPFFuncionario;
            command.Parameters.Add("@NomeFuncionario", MySqlDbType.VarChar).Value = funcionario.NomeFuncionario;
            command.Parameters.Add("@NomeSocialFuncionario", MySqlDbType.VarChar).Value = funcionario.NomeSocialFuncionario;
            command.Parameters.Add("@LoginFuncionario", MySqlDbType.VarChar).Value = funcionario.LoginFuncionario;
            command.Parameters.Add("@TelefoneFuncionario", MySqlDbType.VarChar).Value = funcionario.TelefoneFuncionario;
            command.Parameters.Add("@SenhaFuncionario", MySqlDbType.VarChar).Value = funcionario.SenhaFuncionario;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public string SelectLogin(string vLoginFuncionario)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectLoginFunc(@LoginFuncionario);";
            command.Parameters.Add("@LoginFuncionario", MySqlDbType.VarChar).Value = vLoginFuncionario;
            command.Connection = conexao;
            string LoginFuncionario = (string)command.ExecuteScalar(); 
            conexao.Close();

            if (LoginFuncionario == null)
                LoginFuncionario = "";
            return LoginFuncionario;
        }

        public void UpdateSenha(Funcionario funcionario)
        {
            conexao.Open();
            command.CommandText = "CALL spAlterSenhaFunc(@LoginFuncionario, @SenhaFuncionario);";
            command.Parameters.Add("@LoginFuncionario", MySqlDbType.VarChar).Value = funcionario.LoginFuncionario;
            command.Parameters.Add("@SenhaFuncionario", MySqlDbType.VarChar).Value = funcionario.SenhaFuncionario;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }


        public Funcionario SelectFuncionario(string vLoginFuncionario)
        {
            conexao.Open();
            command.CommandText = "CALL spSelectFunc(@LoginFuncionario);";
            command.Parameters.Add("@LoginFuncionario", MySqlDbType.VarChar).Value = vLoginFuncionario;
            command.Connection = conexao;
            var readFuncionario = command.ExecuteReader();
            var tempFuncionario = new Funcionario();

            if (readFuncionario.Read())
            {
                tempFuncionario.CPFFuncionario = (readFuncionario["CPFFuncionario"].ToString());
                tempFuncionario.NomeFuncionario = readFuncionario["NomeFuncionario"].ToString();
                tempFuncionario.NomeSocialFuncionario = readFuncionario["NomeSocialFuncionario"].ToString();
                tempFuncionario.LoginFuncionario = readFuncionario["LoginFuncionario"].ToString();
                tempFuncionario.TelefoneFuncionario = readFuncionario["TelefoneFuncionario"].ToString();
                tempFuncionario.SenhaFuncionario = readFuncionario["SenhaFuncionario"].ToString();
            };

            readFuncionario.Close();
            conexao.Close();

            return tempFuncionario;
        }


        public void UpdateFuncionario(Funcionario funcinario)
        {
            conexao.Open();
            var updateQuery = "";
            updateQuery += "call spAlterFunc ";
            updateQuery += string.Format("({0}, '{1}', '{2}', '{3}', '{4}', '{5}')",
                funcinario.CPFFuncionario,                     
                funcinario.NomeFuncionario,                   
                funcinario.NomeSocialFuncionario,             
                funcinario.LoginFuncionario,                  
                funcinario.TelefoneFuncionario,               
                funcinario.SenhaFuncionario);                 

            command.Connection = conexao;
            command.CommandText = updateQuery;
            command.ExecuteNonQuery();
            conexao.Close();
        }


        public void DeleteFuncionario(Funcionario funcionario)
        {
            conexao.Open();
            var deleteQuery = "";
            deleteQuery += string.Format("call spDeleteFunc({0})", funcionario.CPFFuncionario);

            command.Connection = conexao;
            command.CommandText = deleteQuery;
            command.ExecuteNonQuery();
            conexao.Close();

            //Conexao db = new Conexao();

            //string deleteQuery = String.Format("CALL spDeleteFunc('{0}')", funcionario);
            //MySqlCommand command = new MySqlCommand(deleteQuery, db.ConectarBD());
            //command.ExecuteNonQuery();

            //db.DesconectarBD();

        }

    }
}
