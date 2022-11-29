using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebVolait.Models;
using WebVolait.ViewModels;

namespace WebVolait.Repositorio
{
    public class Acoes
    {

        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        //********************************** LISTAR CUPOM

        public Cupom ListarCodCupom(int cod)
        {
            var comando = String.Format("select * from tb_cupom where CupomId = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodCupom = cmd.ExecuteReader();
            return ListarCodCupom(DadosCodCupom).FirstOrDefault();
        }

        public Cupom ListarCodCupomByCode(string code)
        {
            var comando = String.Format("select * from tb_cupom where CupomCode = '{0}'", code);
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
                    CupomId = int.Parse(dt["CupomId"].ToString()),
                    Cupomcode = (dt["Cupomcode"].ToString()),
                    Valordesconto = decimal.Parse(dt["Valordesconto"].ToString()),
                    Cupomvalidade = DateTime.Parse(dt["Cupomvalidade"].ToString()),

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
            var TodosCupom = new List<Cupom>
                ();
            while (dt.Read())
            {
                var CupomTemp = new Cupom()
                {
                    CupomId = int.Parse(dt["CupomId"].ToString()),
                    Cupomcode = (dt["Cupomcode"].ToString()),
                    Valordesconto = decimal.Parse(dt["Valordesconto"].ToString()),
                    Cupomvalidade = DateTime.Parse(dt["Cupomvalidade"].ToString()),

                };
                TodosCupom.Add(CupomTemp);
            }
            dt.Close();
            return TodosCupom;
        }

        //********************************** LISTAR CLIENTE

        public Cliente ListarCodCliente(string cod)
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

        public Funcionario ListarCodFuncionario(string cod)
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

        // ********************************** LISTAR PASSAGEM

        public Passagem ListarCodPassagem(int cod)
        {
            var comando = String.Format("select * from vw_passagem where IdPassagem = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodPass = cmd.ExecuteReader();
            return ListarCodPass(DadosCodPass).FirstOrDefault();
        }

        public List<Passagem> ListarCodPass(MySqlDataReader dt)
        {
            var AltAl = new List<Passagem>();
            while (dt.Read())
            {
                var AlTemp = new Passagem()
                {
                    IdPassagem = int.Parse(dt["IdPassagem"].ToString()),
                    NomePassagem = (dt["NomePassagem"].ToString()),
                    DescPassagem = (dt["DescPassagem"].ToString()),
                    ImgPassagem = (dt["ImgPassagem"].ToString()),
                    ValorPassagem = Decimal.Parse(dt["ValorPassagem"].ToString()),
                    Classe = (dt["Classe"].ToString()),
                    IdAeroPartida = (dt["IdAeroPartida"].ToString()),
                    IdAeroDestino = (dt["IdAeroDestino"].ToString()),
                    DtHrPartida = DateTime.Parse(dt["DtHrPartida"].ToString()),
                    DtHrChegada = DateTime.Parse(dt["DtHrChegada"].ToString()),
                    DuracaoVoo = TimeSpan.Parse(dt["DuracaoVoo"].ToString()),
                    CiaAerea = (dt["CiaAerea"].ToString()),

                };
                AltAl.Add(AlTemp);
            }
            dt.Close();
            return AltAl;
        }

        public List<PassagemViewModel> ListarCodPassagem(MySqlDataReader dt)
        {
            var AltAl = new List<PassagemViewModel>();
            while (dt.Read())
            {
                var AlTemp = new PassagemViewModel()
                {
                    IdPassagem = int.Parse(dt["IdPassagem"].ToString()),
                    NomePassagem = (dt["NomePassagem"].ToString()),
                    DescPassagem = (dt["DescPassagem"].ToString()),
                    ImgPassagem = (dt["ImgPassagem"].ToString()),
                    ValorPassagem = Decimal.Parse(dt["ValorPassagem"].ToString()),
                    Classe = (dt["Classe"].ToString()),
                    IdAeroPartida = (dt["IdAeroPartida"].ToString()),
                    IdAeroDestino = (dt["IdAeroDestino"].ToString()),
                    DtHrPartida = DateTime.Parse(dt["DtHrPartida"].ToString()),
                    DtHrChegada = DateTime.Parse(dt["DtHrChegada"].ToString()),
                    DuracaoVoo = TimeSpan.Parse(dt["DuracaoVoo"].ToString()),
                    CiaAerea = (dt["CiaAerea"].ToString()),

                };
                AltAl.Add(AlTemp);
            }
            dt.Close();
            return AltAl;
        }

        public List<Passagem>
            ListarPassagem()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from vw_passagem", con.ConectarBD());
            var DadosPassagem = cmd.ExecuteReader();
            return ListarTodosPassagem(DadosPassagem);
        }

        public List<Passagem>
            ListarTodosPassagem(MySqlDataReader dt)
        {
            var TodosPassagems = new List<Passagem>();
            while (dt.Read())
            {
                var PassagemTemp = new Passagem()
                {
                    IdPassagem = Int16.Parse(dt["IdPassagem"].ToString()),
                    NomePassagem = (dt["NomePassagem"].ToString()),
                    DescPassagem = (dt["DescPassagem"].ToString()),
                    ImgPassagem = (dt["ImgPassagem"].ToString()),
                    ValorPassagem = Decimal.Parse(dt["ValorPassagem"].ToString()),
                    Classe = (dt["Classe"].ToString()),
                    IdAeroPartida = (dt["IdAeroPartida"].ToString()),
                    IdAeroDestino = (dt["IdAeroDestino"].ToString()),
                    DtHrPartida = DateTime.Parse(dt["DtHrPartida"].ToString()),
                    DtHrChegada = DateTime.Parse(dt["DtHrChegada"].ToString()),
                    DuracaoVoo = TimeSpan.Parse(dt["DuracaoVoo"].ToString()),
                    CiaAerea = (dt["CiaAerea"].ToString()),
                };
                TodosPassagems.Add(PassagemTemp);
            }
            dt.Close();
            return TodosPassagems;
        }

        // ********************************** LISTAR COMPRA

        public CompraViewModel ListarCodCompra(int cod)
        {
           var comando = String.Format("select * from vw_compra where NotaFiscal = {0}", cod);
           MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
           var DadosCodCompra = cmd.ExecuteReader();
           return ListarCodCompra(DadosCodCompra).FirstOrDefault();
        }
    
        public CompraViewModel ListarUltimaCodCompra()
        {
            var comando = String.Format("select * from vw_compra order by notafiscal desc limit 1");
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosCodCompra = cmd.ExecuteReader();
            return ListarCodCompra(DadosCodCompra).FirstOrDefault();
        }
        
        public List<CompraViewModel> ListarCodCompra(MySqlDataReader dt)
        {
           var ListCompraViewModel = new List<CompraViewModel>();

           while (dt.Read())
           {
               CompraViewModel tempCompraViewModel = new CompraViewModel()
                {
                    
                        IdPassagem = Int16.Parse(dt["IdPassagem"].ToString()),
                        NomePassagem = (dt["NomePassagem"].ToString()),
                        DescPassagem = (dt["DescPassagem"].ToString()),
                        ImgPassagem = (dt["ImgPassagem"].ToString()),
                        ValorPassagem = Decimal.Parse(dt["ValorPassagem"].ToString()),
                        DtHrPartida = DateTime.Parse(dt["DtHrPartida"].ToString()),
                        DtHrChegada = DateTime.Parse(dt["DtHrChegada"].ToString()),
                        DuracaoVoo = Int16.Parse(dt["DuracaoVoo"].ToString()),
                        CiaAerea = (dt["CiaAerea"].ToString()),
                        Classe = (dt["Classe"].ToString()),

                        NotaFiscal = int.Parse(dt["NotaFiscal"].ToString()),
                        IdAeroPartida = (dt["IdAeroPartida"].ToString()),
                        IdAeroDestino = (dt["IdAeroDestino"].ToString()),
                        CidadeAeroPartida = (dt["CidadeAeroPartida"].ToString()),
                        CidadeAeroDestino = (dt["CidadeAeroDestino"].ToString()),
                        UFAeroPartida = (dt["UFAeroPartida"].ToString()),
                        UFAeroDestino = (dt["UFAeroDestino"].ToString()),
                        QtdPassagem = int.Parse(dt["QtdPassagem"].ToString()),
                        ValorTotal = decimal.Parse(dt["ValorTotal"].ToString()),
                        TipoPgto = (dt["TipoPagto"].ToString())                   

                        //DataCompra = DateTime.Parse(dt["DataCompra"].ToString()),
                        // Cupom = dt["Cupom"].ToString(),
                        // CPFCliente = Int64.Parse(dt["CPFCliente"].ToString()),
                        // CodTipoPagto = (dt["CodTipoPagto"].ToString()),
                    
                    
                        // IdTipoPgto = Int16.Parse(dt["IdTipoPagto"].ToString()),
                };

               ListCompraViewModel.Add(tempCompraViewModel);

           }
           dt.Close();
           return ListCompraViewModel;
        }

        //public List<Compra>
        //    ListarCompra()
        //{
        //    MySqlCommand cmd = new MySqlCommand("Select * from tb_compra", con.ConectarBD());
        //    var DadosCompra = cmd.ExecuteReader();
        //    return ListarTodosCompra(DadosCompra);
        //}

        //public List<Compra>
        //    ListarTodosCompra(MySqlDataReader dt)
        //{
        //    var TodosCompra = new List<Compra>
        //        ();
        //    while (dt.Read())
        //    {
        //        var CompraTemp = new Compra()
        //        {
        //            NotaFiscal = int.Parse(dt["NotaFiscal"].ToString()),
        //            DataCompra = DateTime.Parse(dt["DataCompra"].ToString()),
        //            ValorTotal = decimal.Parse(dt["ValorTotal"].ToString()),
        //            Cupom = (dt["Cupom"].ToString()),
        //            CPFCliente = Int64.Parse(dt["CPFCliente"].ToString()),
        //            CodTipoPagto = (dt["CodTipoPagto"].ToString()),

        //        };
        //        TodosCompra.Add(CompraTemp);
        //    }
        //    dt.Close();
        //    return TodosCompra;
        //}

    }
}
