using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebVolait.Models;

namespace WebVolait.Repositorio
{
    public class Acoes
    {

        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();


        public Cliente ListarCodCliente(int cod)
        {
            var comando = String.Format("select * from tb_cliente where CPFCliente = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodFunc = cmd.ExecuteReader();
            return ListarCodCli(DadosCodFunc).FirstOrDefault();
        }

        public List<Cliente> ListarCodCli(MySqlDataReader dt)
        {
            var AltAl = new List<Cliente>();
            while (dt.Read())
            {
                var AlTemp = new Cliente()
                {
                    CPFCliente = (dt["CPFCliente"].ToString()),
                    NomeCliente = (dt["NomeCliente"].ToString()),
                    NomeSocialCliente = (dt["NomeSocialCliente"].ToString()),
                    EmailCliente = (dt["EmailCliente"].ToString()),
                    TelefoneCliente = (dt["TelefoneCliente"].ToString()),
                    SenhaCliente = (dt["SenhaCliente"].ToString()),

                };
                AltAl.Add(AlTemp);

            }
            dt.Close();
            return AltAl;
        }

        public List<Cliente> ListarCliente()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tb_cliente", con.ConectarBD());
            var DadosCliente = cmd.ExecuteReader();
            return ListarTodosCliente(DadosCliente);
        }

        public List<Cliente> ListarTodosCliente(MySqlDataReader dt)
        {
            var TodosClientes = new List<Cliente>();
            while (dt.Read())
            {
                var ClienteTemp = new Cliente()
                {
                    CPFCliente = (dt["CPFCliente"].ToString()),
                    NomeCliente = (dt["NomeCliente"].ToString()),
                    NomeSocialCliente = (dt["NomeSocialCliente"].ToString()),
                    EmailCliente = (dt["EmailCliente"].ToString()),
                    TelefoneCliente = (dt["TelefoneCliente"].ToString()),
                    SenhaCliente = (dt["SenhaCliente"].ToString()),

                };
                TodosClientes.Add(ClienteTemp);
            }
            dt.Close();
            return TodosClientes;

        }
    }
}