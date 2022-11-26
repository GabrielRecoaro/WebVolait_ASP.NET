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

        public int DuracaoVoo { get; set; }

        public string CiaAerea { get; set; }


        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        MySqlCommand command = new MySqlCommand();

        public void InsertPasssagem(Passagem passagem)
        {
            conexao.Open();
            command.CommandText = "call spInsertPassagem (@NomePassagem, @DescPassagem, @ImgPassagem, @ValorPassagem, @Classe, @CiaAerea, @IdAeroPartida, @IdAeroDestino, @DtHrPartida, @DtHrChegada, @DuracaoVoo);";
            command.Parameters.Add("@NomePassagem", MySqlDbType.VarChar).Value = passagem.NomePassagem;
            command.Parameters.Add("@DescPassagem", MySqlDbType.VarChar).Value = passagem.DescPassagem;
            command.Parameters.Add("@ImgPassagem", MySqlDbType.VarChar).Value = passagem.ImgPassagem;
            command.Parameters.Add("@ValorPassagem", MySqlDbType.Decimal).Value = passagem.ValorPassagem;
            command.Parameters.Add("@Classe", MySqlDbType.VarChar).Value = passagem.Classe;
            command.Parameters.Add("@CiaAerea", MySqlDbType.VarChar).Value = passagem.CiaAerea;
            command.Parameters.Add("@IdAeroPartida", MySqlDbType.VarChar).Value = passagem.IdAeroPartida;
            command.Parameters.Add("@IdAeroDestino", MySqlDbType.VarChar).Value = passagem.IdAeroDestino;
            command.Parameters.Add("@DtHrPartida", MySqlDbType.DateTime).Value = passagem.DtHrPartida;
            command.Parameters.Add("@DtHrChegada", MySqlDbType.DateTime).Value = passagem.DtHrChegada;
            command.Parameters.Add("@DuracaoVoo", MySqlDbType.Int16).Value = passagem.DuracaoVoo;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();
        }

        public Passagem SelectPassagem(string vIdPassagem)
        {
            conexao.Open();
            command.CommandText = "select * from vw_passagem";
            command.Parameters.Add("@IdPassagem", MySqlDbType.Int16).Value = vIdPassagem;
            command.Connection = conexao;
            var readPassagem = command.ExecuteReader();
            var tempPassagem = new Passagem();

            if (readPassagem.Read())
            {
                tempPassagem.NomePassagem = readPassagem["NomePassagem"].ToString();
                tempPassagem.DescPassagem = readPassagem["DescPassagem"].ToString();
                tempPassagem.ImgPassagem = readPassagem["ImgPassagem"].ToString();
                tempPassagem.ValorPassagem = Decimal.Parse(readPassagem["ValorPassagem"].ToString());
                tempPassagem.Classe = readPassagem["Classe"].ToString();
                tempPassagem.CiaAerea = readPassagem["CiaAerea"].ToString();
                tempPassagem.IdAeroPartida = readPassagem["IdAeroPartida"].ToString();
                tempPassagem.IdAeroDestino = readPassagem["IdAeroDestino"].ToString();
                tempPassagem.DtHrPartida = DateTime.Parse(readPassagem["DtHrPartida"].ToString());
                tempPassagem.DtHrChegada = DateTime.Parse(readPassagem["DtHrChegada"].ToString());
                tempPassagem.DuracaoVoo = Int16.Parse(readPassagem["DuracaoVoo"].ToString());
            };

            readPassagem.Close();
            conexao.Close();

            return tempPassagem;
        }



        public void UpdatePassagem(Passagem passagem)
        {
            conexao.Open();
            command.CommandText = "call spAlterPassagem (@IdPassagem, @NomePassagem, @DescPassagem, @ImgPassagem, @ValorPassagem, @Classe, @CiaAerea, @IdAeroPartida, @IdAeroDestino, @DtHrPartida, @DtHrChegada, @DuracaoVoo);";
            command.Parameters.Add("@IdPassagem", MySqlDbType.VarChar).Value = passagem.IdPassagem;
            command.Parameters.Add("@NomePassagem", MySqlDbType.VarChar).Value = passagem.NomePassagem;
            command.Parameters.Add("@DescPassagem", MySqlDbType.VarChar).Value = passagem.DescPassagem;
            command.Parameters.Add("@ImgPassagem", MySqlDbType.VarChar).Value = passagem.ImgPassagem;
            command.Parameters.Add("@ValorPassagem", MySqlDbType.Decimal).Value = passagem.ValorPassagem;
            command.Parameters.Add("@Classe", MySqlDbType.VarChar).Value = passagem.Classe;
            command.Parameters.Add("@CiaAerea", MySqlDbType.VarChar).Value = passagem.CiaAerea;
            command.Parameters.Add("@IdAeroPartida", MySqlDbType.VarChar).Value = passagem.IdAeroPartida;
            command.Parameters.Add("@IdAeroDestino", MySqlDbType.VarChar).Value = passagem.IdAeroDestino;
            command.Parameters.Add("@DtHrPartida", MySqlDbType.DateTime).Value = passagem.DtHrPartida;
            command.Parameters.Add("@DtHrChegada", MySqlDbType.DateTime).Value = passagem.DtHrChegada;
            command.Parameters.Add("@DuracaoVoo", MySqlDbType.Int16).Value = passagem.DuracaoVoo;
            command.Connection = conexao;
            command.ExecuteNonQuery();
            conexao.Close();

            // conexao.Open();
            // @ar updateQuery = "";
            // updateQuery += "call spAlterPassagem ((@IdPassagem, @NomePassagem, @DescPassagem, @ImgPassagem, @Valor decimal(15,2), @Classe, @CiaAerea, @AeroPartida, @AeroDestino, @DtHrPartida, @DtHrChegada, @Duracao)";

            // updateQuery += string.Format("({0}, '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}', '{8}', '{9}', '{10}', '{11}', '{12}' )",

            // passagem.IdPassagem,
            // passagem.NomePassagem,
            // passagem.DescPassagem,
            // passagem.ImgPassagem,
            // passagem.ValorPassagem,
            // passagem.Classe,
            // passagem.CiaAerea,
            // passagem.IdAeroPartida,
            // passagem.IdAeroDestino,
            // passagem.DtHrPartida,
            // passagem.DtHrChegada,
            // passagem.DuracaoVoo);

            // command.Connection = conexao;
            // command.CommandText = updateQuery;
            // command.ExecuteNonQuery();
            // conexao.Close();
        }

        public void DeletePassagem(Passagem passagem)
        {
            conexao.Open();
            var deleteQuery = "";
            deleteQuery += string.Format("call spDeletePassagem({0})", passagem.IdPassagem);

            command.Connection = conexao;
            command.CommandText = deleteQuery;
            command.ExecuteNonQuery();
            conexao.Close();

        }
    }
}

    
