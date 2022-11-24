drop database if exists db_VolaitData;
create database if not exists db_VolaitData;
use db_VolaitData;

/* create table tb_funcaoFunc
(
	IdFuncao int primary key not null auto_increment,
    FuncaoFunc varchar(50)
); */

create table tb_funcionario
(
	CPFFuncionario bigint primary key not null,
    NomeFuncionario varchar(100) not null,
    NomeSocialFuncionario varchar(100) null,
    LoginFuncionario varchar(100) not null,
    TelefoneFuncionario varchar(16) not null,
    SenhaFuncionario varchar(100) not null
    /* IdFuncao int,
    constraint fk_funcao foreign key(IdFuncao) references tb_funcaoFunc(IdFuncao) */
);


create table tb_cliente
(
	CPFCliente bigint primary key not null,
    NomeCliente varchar(100) not null,
    NomeSocialCliente varchar(100) null,
    LoginCliente varchar(100) not null,
    TelefoneCliente varchar(11) not null,
    SenhaCliente varchar(100) not null
);

create table tb_tipoPagto
(
	CodTipoPagto int primary key not null auto_increment,
    TipoPagto varchar(30)
);

create table tb_cupom(

	CupomId int auto_increment primary key,
	Cupomcode char(9) not null,
	Valordesconto decimal not null,
	Cupomvalidade date
);

insert into tb_cupom values (default, "QWERTYUIO", 100.00, "2022-12-01"),(default, "ZXCVBNMLP", 200.00, "2022-12-01"),(default, "ASDFGHJKL", 50.00, "2022-11-05");

create table tb_compra
(
	NotaFiscal int auto_increment primary key not null,
    DataCompra date,
    ValorTotal decimal(15,2),
    CPFCliente bigint not null,
    Cupom int,
    CodTipoPagto int,
    constraint fk_cpfCli foreign key(CPFCliente) references tb_cliente(CPFCliente),
    constraint fk_tipoPagto foreign key(CodTipoPagto) references tb_tipoPagto(CodTipoPagto),
    constraint fk_cupom foreign key(Cupom) references tb_cupom(CupomId)
);

create table tb_classeVoo
(
	IdClasse int primary key not null auto_increment,
    Classe varchar(50) not null
);

create table tb_ciaAerea
(
	CNPJCiaAerea bigint primary key not null,
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
    CNPJCiaAerea bigint not null,
    constraint fk_ciaAerea foreign key(CNPJCiaAerea) references tb_ciaAerea(CNPJCiaAerea),
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
    CNPJCiaAerea bigint,
    IdPassagem int,
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
    NotaFiscal int not null,
    IdPassagem int,
    constraint fk_passagemCompra foreign key(IdPassagem) references tb_passagem(IdPassagem),
    constraint fk_nota foreign key(NotaFiscal) references tb_compra(NotaFiscal)
);

-- Inserts simples
/*insert into tb_funcaoFunc values(default, "Administrador"), (default, "Funcionario");*/

insert into tb_tipopagto values(Default, 'Cartão de Crédito'), (Default, 'Cartão de Débito'), (Default, 'Cheque'), (Default, 'Boleto Bancário'), (Default, 'PIX');

insert into tb_classeVoo values(default, "Classe econômica"), (default, "Classe executiva"), (default, "1ª classe");

insert into tb_funcionario values('98623688689', 'Bruno Silva Bastos', 'Bruno', 'bruno.bastos3@etec.sp.gov.br', '11956383957', 'bsb398'),
('57345699832', 'Gabriel Jard Recoaro Silva', 'Gabriel', 'gabriel.silva2615@etec.sp.gov.br', '11944485007', 'gjs261'),
('78456377925', 'Filipe Ferreiro Pereira', 'Filipe', 'felipe.pereira252@etec.sp.gov.br', '11989652235', 'ffp252'),
('56487933278', 'Pedro Augusto Souza Ribeiro de Aquino', 'Pedro Augusto', 'pedro.aquino@etec.sp.gov.br', '11977188102', 'paa564');

insert into tb_cliente values('65789577234', 'Judith Brito',null, 'jud.brito@gmail.com', '11947265184', 'jud111'),
('57689455721', 'Elio Gaspari', 'Elio', 'elio.gaspari@gmail.com', '11976119231', 'eli999'),
('90834677903', 'Anna Almeida', null, 'annaalmeida@gmail.com', '11971694278', 'alm321'),
('96745372198', 'Igor Resende', null, 'igosende@gmail.com', '11989762241', 'igg345'),
('78545623745', 'Laura Goes', null, 'laura.goes@gmail.com', '11987619433', 'lau679');

insert into tb_ciaAerea values (33937681000178, "Latam Airlines"),
(09296295000160, "Azul Linhas Aéreas"),
(07575651000159, "Gol Linhas Aéreas"),
(02575829000148, "Avianca"),
(00146461000177, "Delta Air Lines"),
(08734301000150, "Qatar Airways"),
(08692080000103, "Emirates Airlines"),
(10576103000158, "Turkish Airlines"),
(33013988000182, "Air France"),
(50710730000316, "British Airways"),
(33461740000184, "Lufthansa"),
(33136896001161, "Tap Air Portugal");


-- Cadastrar funcionário
drop procedure if exists spInsertFunc;
DELIMITER $$
CREATE PROCEDURE spInsertFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vLoginFunc varchar(100), vTelefoneFunc char(11), vSenhaFunc varchar(100)) 

BEGIN
	INSERT INTO tb_funcionario (CPFFuncionario, NomeFuncionario, NomeSocialFuncionario, LoginFuncionario, TelefoneFuncionario, SenhaFuncionario) VALUES (vCpfFunc, vNomeFunc, vNomeSocialFunc, vLoginFunc, vTelefoneFunc, vSenhaFunc);
END $$

CALL spInsertFunc(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654"); 

DELIMITER $$

-- Cadastrar cliente
drop procedure if exists spInsertCli;
DELIMITER $$
CREATE PROCEDURE spInsertCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vLoginCliente varchar(100), vTelefoneCli char(16), vSenhaCli varchar(100)) 

BEGIN
	INSERT INTO tb_cliente (CPFCliente, NomeCliente, NomeSocialCliente, LoginCliente, TelefoneCliente, SenhaCliente) VALUES (vCpfCli, vNomeCli, vNomeSocialCli, vLoginCliente, vTelefoneCli, vSenhaCli);
END $$

CALL spInsertCli(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654"); 

DELIMITER $$

select * from tb_funcionario;
select * from tb_cliente;

-- Select funcionário
drop procedure if exists spSelectFunc;
DELIMITER $$
CREATE PROCEDURE spSelectFunc(vLoginFuncionario varchar(100))

BEGIN
	select CPFFuncionario, NomeFuncionario, NomeSocialFuncionario, LoginFuncionario, TelefoneFuncionario, SenhaFuncionario from tb_funcionario where LoginFuncionario = vLoginFuncionario;
END $$


DELIMITER $$

-- Select cliente
drop procedure if exists spSelectCli;
DELIMITER $$
CREATE PROCEDURE spSelectCli(vLoginCliente varchar(100))

BEGIN
	select * from tb_cliente where LoginCliente = vLoginCliente;
END $$



DELIMITER $$

-- Select login usuário
drop procedure if exists spSelectLoginFunc;
DELIMITER $$
CREATE PROCEDURE spSelectLoginFunc(vLoginFuncionario varchar(100))

BEGIN
	select LoginFuncionario from tb_funcionario where LoginFuncionario = vLoginFuncionario;
END $$

CALL spSelectLoginFunc("brendaberzin@gmail.com");

DELIMITER $$

-- Select login cliente
drop procedure if exists spSelectLoginCli;
DELIMITER $$
CREATE PROCEDURE spSelectLoginCli(vLoginCliente varchar(100))

BEGIN
	select LoginCliente from tb_cliente where LoginCliente = vLoginCliente;
END $$

CALL spSelectLoginCli("brendaberzin@gmail.com");

DELIMITER $$

-- Alterar funcionário 
drop procedure if exists spAlterFunc;
DELIMITER $$
CREATE PROCEDURE spAlterFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vLoginFunc varchar(100), vTelefoneFunc char(11), vSenhaFunc varchar(100)) 

BEGIN
		UPDATE tb_funcionario SET NomeFuncionario = vNomeFunc, NomeSocialFuncionario = vNomeSocialFunc, LoginFuncionario = vLoginFunc, TelefoneFuncionario = vTelefoneFunc, SenhaFuncionario = vSenhaFunc where CPFFuncionario = vCpfFunc;
END $$

CALL spAlterFunc(78456377925, "Otávio de Paula", null, "otavio@gmail.com", "11989652235", "odp667");

DELIMITER $$

-- Alterar cliente
drop procedure if exists spAlterCli;
DELIMITER $$
CREATE PROCEDURE spAlterCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vLoginCliente varchar(100), vTelefoneCli char(11), vSenhaCli varchar(100)) 

BEGIN
		UPDATE tb_cliente SET NomeCliente = vNomeCli, NomeSocialCliente = vNomeSocialCLi, LoginCliente = vLoginCliente, TelefoneCliente = vTelefoneCli, SenhaCliente = vSenhaCli where CPFCliente = vCpfCli;
END $$

CALL spAlterCli(57689455721, 'Elio Gaspari', null, 'elio.gaspari@gmail.com', '12976119231', 'eli999');

DELIMITER $$

select * from tb_funcionario;

-- Alterar senha funcionário
drop procedure if exists spAlterSenhaFunc;
DELIMITER $$
CREATE PROCEDURE spAlterSenhaFunc(vCpfFunc bigint, vSenhaFunc varchar(100))

BEGIN
	UPDATE tb_funcionario set SenhaFuncionario = vSenhaFunc where CPFFuncionario = vCpfFunc;
END $$

CALL spAlterSenhaFunc (57345699832, "gjs262");

DELIMITER $$

select * from tb_cliente;

-- Alterar senha cliente
drop procedure if exists spAlterSenhaCli;
DELIMITER $$
CREATE PROCEDURE spAlterSenhaCli(vLoginCliente varchar(100), vSenhaCli varchar(100))

BEGIN
	UPDATE tb_cliente set SenhaCliente = vSenhaCli where LoginCliente = vLoginCliente;
END $$



DELIMITER $$

-- Deletar funcionário
drop procedure if exists spDeleteFunc;
DELIMITER $$
CREATE PROCEDURE spDeleteFunc(vCpfFunc bigint)

BEGIN
	DELETE from tb_funcionario where CPFFuncionario = vCpfFunc;
END $$

CALL spDeleteFunc(98623688689);

DELIMITER $$

-- Deletar cliente
drop procedure if exists spDeleteCli;
DELIMITER $$
CREATE PROCEDURE spDeleteCli(vCpfCli bigint)

BEGIN
	DELETE from tb_cliente where CPFCliente = vCpfCli;
END $$

CALL spDeleteCli(78545623745);

DELIMITER $$

-- Select tipos de pagamento
drop procedure if exists spSelectTipoPagto;
DELIMITER $$
CREATE PROCEDURE spSelectTipoPagto(vTipoPagto int)

BEGIN
	select TipoPagto from tb_tipoPagto where CodTipoPagto = vTipoPagto;
END $$

DELIMITER $$

-- Insert cupom
drop procedure if exists spInsertCupom;
DELIMITER $$
CREATE PROCEDURE spInsertCupom(vCupom char(6), vDescCupom varchar(100), vValor decimal(15,2))

BEGIN
	insert into tb_cupom (Cupom, DescCupom, ValorDesconto) values (vCupom, vDescCupom, vValor);
END $$

CALL spInsertCupom ("KWZ317", "Desconto de R$ 300,00 no valor total da compra", "300.00")

DELIMITER $$

-- Alterar cupom
drop procedure if exists spAlterCupom;
DELIMITER $$
CREATE PROCEDURE spAlterCupom(vCupom char(6), vDescCupom varchar(100), vValor decimal(15,2))

BEGIN
	update tb_cupom set DescCupom = vDescCupom, ValorDesconto = vValor where vCupom = Cupom;
END $$

CALL spAlterCupom("KWZ317", "Desconto de R$ 100,00 no valor total da compra", "100.00");

DELIMITER $$

-- Deletar cupom
drop procedure if exists spDeleteCupom;
DELIMITER $$
CREATE PROCEDURE spDeleteCupom(vCupom char(6))

BEGIN
	delete from tb_cupom where Cupom = vCupom;
END $$

CALL spDeleteCupom("KWZ317");

DELIMITER $$

/*
NotaFiscal int auto_increment primary key not null,
    DataCompra date,
    ValorTotal decimal(15,2),
    CPFCliente bigint not null,
    Cupom char(6),
    CodTipoPagto int,
*/

/*NotaFiscal int not null,
    IdPassagem int,
    constraint fk_passagemCompra foreign key(IdPassagem) references tb_passagem(IdPassagem),
    constraint fk_nota foreign key(NotaFiscal) references tb_compra(NotaFiscal)
*/

-- Insert compra
drop procedure if exists spInsertCompra;
DELIMITER $$
CREATE PROCEDURE spInsertCompra( vData date, vTotal decimal(15,2), vCpfCliente bigint, vCupom char(6), vTipoPagto int)

BEGIN
	insert into tb_compra (NotaFiscal, DataCompra, ValorTotal, CPFCliente, Cupom, CodTipoPagto) values (default, vData, vTotal, vCpfCliente, vCupom, (select IdTipoPagto from tb_tipoPagto where TipoPagto = vTipoPagto));
END $$

DELIMITER $$

-- Select compra
DELIMITER $$
CREATE PROCEDURE spSelectCompra(vNotaFiscal int, vData date, vCpfCliente bigint)

BEGIN
	select NotaFiscal, DataCompra, ValorTotal, CPFCliente, Cupom, CodTipoPagto from tb_compra where NotaFiscal = vNotaFiscal or DataCompra = vData or CPFCliente = vCpfCliente;
END $$

CALL spSelectCompra(52673833846);

DELIMITER $$

-- Alterar valor total compra
DELIMITER $$
CREATE PROCEDURE spAlterValorCompra(vNotaFiscal int, vTotal decimal(15,2))

BEGIN
	update tb_compra set ValorTotal = vTotal where NotaFiscal = vNotaFiscal;
END $$

CALL spAlterValorCompra(1, "1256.00");


DELIMITER $$
CREATE PROCEDURE spInsertPassagem(vNomePassagem varchar(200), vDescPassagem varchar(500), vImgPassagem varchar(100), vValor decimal(15,2), 
				 vClasse int, vCiaAerea bigint, vAeroPartida char(3), vAeroDestino char(3))

BEGIN
    insert into tb_passagem (NomePassagem, DescPassagem, ImgPassagem, ValorPassagem, IdClasse, CNPJCiaAerea, IdAeroPartida, IdAeroDestino) 
    values (default, vNomePassagem, vDescPassagem,  vImgPassagem, vValor, (SELECT IdClasse from tb_classe where Classe = vClasse limit 1), (SELECT IdCiaAerea from tb_ciaAerea where CiaAerea = vCiaAerea limit 1), vAeroPartida, vAeroDestino);
END $$
						

DELIMITER $$



select * from tb_compra;
-- Alterar compra

-- Alterar compra


-- Selects simples
select * from tb_funcionario;
select * from tb_cliente;
select * from vw_compra;
select * from vw_passagem;
