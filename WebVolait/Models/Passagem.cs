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
    public class Passagem
    {

        public int IdPassagem { get; set; }

        public string NomePassagem { get; set; }

        public string DescPassagem { get; set; }

        public string ImgPassagem { get; set; }

        public decimal ValorPassagem { get; set; }

        public string Classe { get; set; }

        public string IdAeroPartida { get; set; }

        public string IdAeroDestino { get; set; }

        public DateTime DtHrPartida { get; set; }

        public DateTime DtHrChegada { get; set; }

        public string DuracaoVoo { get; set; }

        public string CiaAerea { get; set; }

   

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertPasssagem(Passagem passagem)
        {
            conexao.Open();
            command.CommandText = "call spInsertPassagem (@NomePassagem, @DescPassagem, @IdAeroOrigem, @IdAeroDestino, @DtHrPartida, @DtHrChegada, @ImgPassagem, @ValorPassagem, @Classe );";
            command.Parameters.Add("@IdPassagem", MySqlDbType.VarChar).Value = passagem.IdPassagem;
            command.Parameters.Add("@NomePassagem", MySqlDbType.VarChar).Value = passagem.NomePassagem;
            command.Parameters.Add("@DescPassagem", MySqlDbType.VarChar).Value = passagem.DescPassagem;
            command.Parameters.Add("@Origem", MySqlDbType.VarChar).Value = passagem.Origem;
            command.Parameters.Add("@Destino", MySqlDbType.VarChar).Value = passagem.Destino;
            command.Parameters.Add("@IdAeroOrigem", MySqlDbType.VarChar).Value = passagem.IdAeroOrigem;
            command.Parameters.Add("@IdAeroDestino", MySqlDbType.VarChar).Value = passagem.IdAeroDestino;
            command.Parameters.Add("@DtHrPartida", MySqlDbType.VarChar).Value = passagem.DtHrPartida;
            command.Parameters.Add("@DtHrChegada", MySqlDbType.VarChar).Value = passagem.DtHrChegada;
            command.Parameters.Add("@ImgPassagem", MySqlDbType.VarChar).Value = passagem.ImgPassagem;
            command.Parameters.Add("@ValorPassagem", MySqlDbType.VarChar).Value = passagem.ValorPassagem;
            command.Parameters.Add("@Classe", MySqlDbType.VarChar).Value = passagem.Classe;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

    }
}