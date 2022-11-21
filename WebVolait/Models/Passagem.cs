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

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string CidadeAeroOrigem { get; set; }

        public string CidadeAeroDestino { get; set; }

        public DateTime DtHrPartida { get; set; }

        public DateTime DtHrChegada { get; set; }

        public string ImgPassagem { get; set; }

        public decimal ValorPassagem { get; set; }
        
        public string Classe { get; set; }

        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertPasssagem(Passagem passagem)
        {
            conexao.Open();
            command.CommandText = "call spInsertPassagem (@IdPassagem, @NomePassagem, @DescPassagem, @Origem, @Destino, @CidadeAeroOrigem, @CidadeAeroDestino, @DtHrPartida, @DtHrChegada, @ImgPassagem, @ValorPassagem, @Classe );";
            command.Parameters.Add("@IdPassagem", MySqlDbType.VarChar).Value = passagem.IdPassagem;
            command.Parameters.Add("@NomePassagem", MySqlDbType.VarChar).Value = passagem.NomePassagem;
            command.Parameters.Add("@DescPassagem", MySqlDbType.VarChar).Value = passagem.DescPassagem;
            command.Parameters.Add("@Origem", MySqlDbType.VarChar).Value = passagem.Origem;
            command.Parameters.Add("@Destino", MySqlDbType.VarChar).Value = passagem.Destino;
            command.Parameters.Add("@CidadeAeroOrigem", MySqlDbType.VarChar).Value = passagem.CidadeAeroOrigem;
            command.Parameters.Add("@CidadeAeroDestino", MySqlDbType.VarChar).Value = passagem.CidadeAeroDestino;
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