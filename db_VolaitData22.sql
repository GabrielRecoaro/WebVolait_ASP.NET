drop database if exists db_VolaitData;
create database if not exists db_VolaitData;
use db_VolaitData;

create table tb_funcaoFunc
(
	IdFuncao int primary key not null auto_increment,
    FuncaoFunc varchar(50)
);

create table tb_funcionario
(
	CPFFuncionario bigint primary key not null,
    NomeFuncionario varchar(100) not null,
    NomeSocialFuncionario varchar(100) null,
    LoginFuncionario varchar(100) not null,
    TelefoneFuncionario varchar(11) not null,
    SenhaFuncionario char(6) not null,
    IdFuncao int,
    constraint fk_funcao foreign key(IdFuncao) references tb_funcaoFunc(IdFuncao)
);

create table tb_cliente
(
	CPFCliente bigint primary key not null,
    NomeCliente varchar(100) not null,
    NomeSocialCliente varchar(100) null,
    LoginCliente varchar(70) not null,
    TelefoneCliente varchar(11) not null,
    SenhaCliente char(6)
);

create table tb_tipoPagto
(
	CodTipoPagto int primary key not null auto_increment,
    TipoPagto varchar(30)
);

create table tb_cupom
(
	Cupom int not null primary key,
    DescCupom varchar(100),
    ValorDesconto decimal(15,2)
);

create table tb_compra
(
	NotaFiscal bigint primary key not null,
    DataCompra date,
    ValorTotal decimal(15,2),
    CPFCliente bigint not null,
    Cupom int,
    CodTipoPagto int not null auto_increment,
    constraint fk_cpfCli foreign key(CPFCliente) references tb_cliente(CPFCliente),
    constraint fk_tipoPagto foreign key(CodTipoPagto) references tb_tipoPagto(CodTipoPagto),
    constraint fk_cupom foreign key(Cupom) references tb_cupom(Cupom)
);

create table tb_classeVoo
(
	IdClasse int primary key not null auto_increment,
    Classe varchar(50) not null
);

create table tb_ciaAerea
(
	CNPJCiaAerea int primary key not null,
    CiaAerea varchar(50) not null
);

create table tb_aero
(
	IdAero char(3) primary key not null,
    CidadeAero varchar(50) not null,
    UfAero char(2) not null
);

create table tb_passagem
(
	IdPassagem int primary key not null auto_increment,
    NomePassagem varchar(200) not null,
    DescPassagem varchar(500) not null,
    ImgPassagem blob,
    ValorPassagem decimal(15,2),
    IdClasse int,
    IdAeroPartida char(3),
    IdAeroDestino char(3),
    constraint fk_classe foreign key(IdClasse) references tb_classeVoo(IdClasse),
	constraint fk_aeroPartida foreign key(IdAeroPartida) references tb_aero(IdAero),
    constraint fk_aeroDestino foreign key(IdAeroDestino) references tb_aero(IdAero)
);

create table tb_voo
(
	IdVoo int primary key not null,
    DtHrPartida datetime not null,
    DtHrChegada datetime not null,
    IdAeroPartida char(3),
    IdAeroDestino char(3),
    DuracaoVoo int not null,
    CNPJCiaAerea int,
    IdPassagem int,
    constraint fk_ciaAerea foreign key(CNPJCiaAerea) references tb_ciaAerea(CNPJCiaAerea),
    constraint fk_aeroPartidaVoo foreign key(IdAeroPartida) references tb_aero(IdAero),
    constraint fk_aeroDestinoVoo foreign key(IdAeroDestino) references tb_aero(IdAero)
);

create table tb_passagemVoo
(
	IdPassagem int not null,
    IdVoo int not null,
	constraint fk_passagem foreign key(IdPassagem) references tb_passagem(IdPassagem),
    constraint fk_voo foreign key(IdVoo) references tb_voo(IdVoo)
);

create table tb_itemCompra
(
    NotaFiscal bigint not null,
    IdPassagem int,
    QtdItemCompra int,
    constraint fk_passagemCompra foreign key(IdPassagem) references tb_passagem(IdPassagem),
    constraint fk_nota foreign key(NotaFiscal) references tb_compra(NotaFiscal)
);

-- Inserts simples
insert into tb_funcaoFunc values(default, "Administrador"), (default, "Funcionario");
insert into tb_tipopagto values(Default, 'Cartão de Crédito'), (Default, 'Cartão de Débito'), (Default, 'Cheque'), (Default, 'Boleto Bancário'), (Default, 'PIX');
insert into tb_classeVoo values(default, "Classe econômica"), (default, "Classe executiva"), (default, "1ª classe");

select * from tb_cliente;
select * from tb_funcionario;


-- Cadastrar funcionário
drop procedure if exists spInsertFunc;
DELIMITER $$
CREATE PROCEDURE spInsertFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vLoginFunc varchar(100), vTelefoneFunc char(11), vSenhaFunc char(6), vIdFuncao int) 

BEGIN
		INSERT INTO tb_funcionario (CPFFuncionario, NomeFuncionario, NomeSocialFuncionario, LoginFuncionario, TelefoneFuncionario, SenhaFuncionario, IdFuncao) VALUES (vCpfFunc, vNomeFunc, vNomeSocialFunc, vLoginFunc, vTelefoneFunc, vSenhaFunc, vIdFuncao);
END $$

CALL spInsertFunc(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654", 1); 

-- Cadastrar cliente
drop procedure if exists spInsertCli;
DELIMITER $$
CREATE PROCEDURE spInsertCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vLoginCli varchar(100), vTelefoneCli char(11), vSenhaCli char(6)) 

BEGIN
	INSERT INTO tb_cliente (CPFCliente, NomeCliente, NomeSocialCliente, LoginCliente, TelefoneCliente, SenhaCliente) VALUES (vCpfCli, vNomeCli, vNomeSocialCli, vLoginCli, vTelefoneCli, vSenhaCli);
END $$

CALL spInsertCli(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654");

-- Select Login Cliente

delimiter $$
CREATE PROCEDURE spSelectLogin(vLoginCliente varchar(70))
begin
select LoginCliente from tb_cliente where LoginCliente = vLoginCliente;
End $$