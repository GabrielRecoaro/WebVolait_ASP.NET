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
    public class Funcionario
    {
        [Display(Name = "CPF")]
        public string CPFFuncionario { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        public string NomeFuncionario { get; set; }

        [Display(Name = "Nome Social")]
        [MaxLength(50)]
        public string NomeSocialFuncionario { get; set; }

        [Display(Name = "E-mail")]
        public string LoginFuncionario { get; set; }

        [Display(Name = "Número de Telefone")]
        public string TelefoneFuncionario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public string SenhaFuncionario { get; set; }

        [Display(Name = "Função")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [MaxLength(100)]
        public int FuncaoFuncionario { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertFuncionario(Funcionario funcionario)
        {
            conexao.Open();
            command.CommandText = "call spInsertFunc (@CPFFuncionario, @NomeFuncionario, @NomeSocialFuncionario, @LoginFuncionario, @TelefoneFuncionario, @SenhaFuncionario, @IdFuncao);";
            command.Parameters.Add("@CPFFuncionario", MySqlDbType.VarChar).Value = funcionario.CPFFuncionario;
            command.Parameters.Add("@NomeFuncionario", MySqlDbType.VarChar).Value = funcionario.NomeFuncionario;
            command.Parameters.Add("@NomeSocialFuncionario", MySqlDbType.VarChar).Value = funcionario.NomeSocialFuncionario;
            command.Parameters.Add("@LoginFuncionario", MySqlDbType.VarChar).Value = funcionario.LoginFuncionario;
            command.Parameters.Add("@TelefoneFuncionario", MySqlDbType.VarChar).Value = funcionario.TelefoneFuncionario;
            command.Parameters.Add("@SenhaFuncionario", MySqlDbType.VarChar).Value = funcionario.SenhaFuncionario;
            command.Parameters.Add("@IdFuncao", MySqlDbType.VarChar).Value = funcionario.FuncaoFuncionario;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

    }
}