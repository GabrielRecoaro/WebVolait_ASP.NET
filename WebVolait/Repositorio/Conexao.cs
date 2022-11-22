using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebVolait.Repositorio
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexaolocaldatabase"].ConnectionString);
        public static string msg;

        public MySqlConnection ConectarBD()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection DesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao desconectar" + erro.Message;
            }
            return cn;

        }
    }
}