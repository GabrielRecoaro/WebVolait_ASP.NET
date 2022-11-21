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

        //********************************** LISTAR CUPOM

        public Cupom ListarCodCupom(int cod)
        {
            var comando = String.Format("select * from tb_cupom where CPFCupom = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodCupom = cmd.ExecuteReader();
            return ListarCodCupom(DadosCodCupom).FirstOrDefault();
        }

        public List<Cupom>
    ListarCodCupom(MySqlDataReader dt)
        {
            var AltAl = new List<Cupom>
                ();
            while (dt.Read())
            {
                var AlTemp = new Cupom()
                {
                    IdCupom = (dt["Cupom"].ToString()),
                    DescCupom = (dt["DescCupom"].ToString()),
                    ValorCupom = ushort.Parse(dt["ValorCupom"].ToString()),

                };
                AltAl.Add(AlTemp);

            }
            dt.Close();
            return AltAl;
        }

        public List<Cupom>
            ListarCupom()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tb_cupom", con.ConectarBD());
            var DadosCupom = cmd.ExecuteReader();
            return ListarTodosCupom(DadosCupom);
        }

        public List<Cupom>
            ListarTodosCupom(MySqlDataReader dt)
        {
            var TodosCupoms = new List<Cupom>
                ();
            while (dt.Read())
            {
                var CupomTemp = new Cupom()
                {
                    IdCupom = (dt["Cupom"].ToString()),
                    DescCupom = (dt["DescCupom"].ToString()),
                    ValorCupom = ushort.Parse(dt["ValorCupom"].ToString()),

                };
                TodosCupoms.Add(CupomTemp);
            }
            dt.Close();
            return TodosCupoms;
        }

        //********************************** LISTAR CLIENTE

        public Cliente ListarCodCliente(int cod)
        {
            var comando = String.Format("select * from tb_cliente where CPFCliente = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodCli = cmd.ExecuteReader();
            return ListarCodCli(DadosCodCli).FirstOrDefault();
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
                    LoginCliente = (dt["LoginCliente"].ToString()),
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
                    LoginCliente = (dt["LoginCliente"].ToString()),
                    TelefoneCliente = (dt["TelefoneCliente"].ToString()),
                    SenhaCliente = (dt["SenhaCliente"].ToString()),

                };
                TodosClientes.Add(ClienteTemp);
            }
            dt.Close();
            return TodosClientes;
        }

        //********************************** LISTAR FUNCIONARIO

        public Funcionario ListarCodFuncionario(int cod)
        {
                var comando = String.Format("select * from tb_funcionario where CPFFuncionario = {0}", cod);
                MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
                var DadosCodFunc = cmd.ExecuteReader();
                return ListarCodFunc(DadosCodFunc).FirstOrDefault();
        }

            
        public List<Funcionario>

        ListarCodFunc(MySqlDataReader dt)
            {
                var AltAl = new List<Funcionario>
                    ();
                while (dt.Read())
                {
                    var AlTemp = new Funcionario()
                    {
                        CPFFuncionario = (dt["CPFFuncionario"].ToString()),
                        NomeFuncionario = (dt["NomeFuncionario"].ToString()),
                        NomeSocialFuncionario = (dt["NomeSocialFuncionario"].ToString()),
                        LoginFuncionario = (dt["LoginFuncionario"].ToString()),
                        TelefoneFuncionario = (dt["TelefoneFuncionario"].ToString()),
                        SenhaFuncionario = (dt["SenhaFuncionario"].ToString()),


                    };
                    AltAl.Add(AlTemp);

                }
                dt.Close();
                return AltAl;
            }

            public List<Funcionario>
                ListarFuncionario()
            {
                MySqlCommand cmd = new MySqlCommand("Select * from tb_funcionario", con.ConectarBD());
                var DadosFuncionario = cmd.ExecuteReader();
                return ListarTodosFuncionario(DadosFuncionario);
            }

            public List<Funcionario>
                ListarTodosFuncionario(MySqlDataReader dt)
            {
                var TodosFuncionarios = new List<Funcionario>
                    ();
                while (dt.Read())
                {
                    var FuncionarioTemp = new Funcionario()
                    {
                        CPFFuncionario = (dt["CPFFuncionario"].ToString()),
                        NomeFuncionario = (dt["NomeFuncionario"].ToString()),
                        NomeSocialFuncionario = (dt["NomeSocialFuncionario"].ToString()),
                        LoginFuncionario = (dt["LoginFuncionario"].ToString()),
                        TelefoneFuncionario = (dt["TelefoneFuncionario"].ToString()),
                        SenhaFuncionario = (dt["SenhaFuncionario"].ToString()),

                    };
                    TodosFuncionarios.Add(FuncionarioTemp);
                }

                dt.Close();

                return TodosFuncionarios;

            }

        public Passagem ListarCodPassagem(int cod)
        {
            var comando = String.Format("select * from tb_passagem where IdPassagem = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodPass = cmd.ExecuteReader();
            return ListarCodPass(DadosCodPass).FirstOrDefault();
        }

        public List<Passagem>
    ListarCodPass(MySqlDataReader dt)
        {
            var AltAl = new List<Passagem>
                ();
            while (dt.Read())
            {
                var AlTemp = new Passagem()
                {

                    //NomePassagem = (dt["NomePassagem"].ToString()),
                    //DescPassagem = (dt["DescPassagem"].ToString()),
                    //ImgPassagem = (dt["ImgPassagem"].ToString()),
                    //ValorPassagem = (dt["ValorPassagem"].ToString()),

                };
                AltAl.Add(AlTemp);

            }
            dt.Close();
            return AltAl;
        }

        public List<Passagem>
            ListarPassagem()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tb_passagem", con.ConectarBD());
            var DadosPassagem = cmd.ExecuteReader();
            return ListarTodosPassagem(DadosPassagem);
        }

        public List<Passagem>
            ListarTodosPassagem(MySqlDataReader dt)
        {
            var TodosPassagems = new List<Passagem>
                ();
            while (dt.Read())
            {
                var PassagemTemp = new Passagem()
                {

                    //NomePassagem = (dt["NomePassagem"].ToString()),
                    //DescPassagem = (dt["DescPassagem"].ToString()),
                    //ImgPassagem = (dt["ImgPassagem"].ToString()),
                    //ValorPassagem = (dt["ValorPassagem"].ToString()),

                };
                TodosPassagems.Add(PassagemTemp);
            }
            dt.Close();
            return TodosPassagems;
        }

    }
}