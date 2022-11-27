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
	CupomCode char(9) not null,
	ValorDesconto decimal not null,
	CupomValidade date
);

create table tb_classe
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
    NomeAero varchar(100) not null,
    CidadeAero varchar(50) not null,
    UfAero char(2) 
);

create table tb_passagem
(
	IdPassagem int primary key not null auto_increment,
    NomePassagem varchar(200) not null,
    DescPassagem varchar(500) not null,
    ImgPassagem varchar(100),
    ValorPassagem decimal(15,2),
    IdClasse int,
    IdAeroPartida char(3),
    IdAeroDestino char(3),
    DtHrPartida datetime not null,
    DtHrChegada datetime not null,
    DuracaoVoo int not null,
    CNPJCiaAerea bigint not null,
    constraint fk_ciaAerea foreign key(CNPJCiaAerea) references tb_ciaAerea(CNPJCiaAerea),
    constraint fk_classe foreign key(IdClasse) references tb_classe(IdClasse),
	constraint fk_aeroPartida foreign key(IdAeroPartida) references tb_aero(IdAero),
    constraint fk_aeroDestino foreign key(IdAeroDestino) references tb_aero(IdAero)
);

create table tb_compra
(
	NotaFiscal int auto_increment primary key not null,
    DataCompra datetime,
    QtdPassagem int,
    ValorTotal decimal(15,2),
    CPFCliente bigint not null,
    Cupom int,
    CodTipoPagto int,
    IdPassagem int,
    constraint fk_cpfCli foreign key(CPFCliente) references tb_cliente(CPFCliente),
    constraint fk_tipoPagto foreign key(CodTipoPagto) references tb_tipoPagto(CodTipoPagto),
    constraint fk_cupom foreign key(Cupom) references tb_cupom(CupomId),
    constraint fk_passagem foreign key(IdPassagem) references tb_passagem(IdPassagem)
);

create table tb_itemCompra
(
    NotaFiscal int not null,
    IdPassagem int,
    QtdPassagem int,
    constraint fk_passagemCompra foreign key(IdPassagem) references tb_passagem(IdPassagem),
    constraint fk_nota foreign key(NotaFiscal) references tb_compra(NotaFiscal)
);

-- Inserts simples
/*insert into tb_funcaoFunc values(default, "Administrador"), (default, "Funcionario");*/

insert into tb_tipopagto values(Default, 'Cartão de Crédito'), (Default, 'Cartão de Débito'), (Default, 'Cheque'), (Default, 'Boleto Bancário'), (Default, 'PIX');

insert into tb_classe values(default, "Classe econômica"), (default, "Classe executiva"), (default, "1ª classe");

insert into tb_cupom values (default, "QWERTYUIO", 100.00, "2022-12-01"),(default, "ZXCVBNMLP", 200.00, "2022-12-01"),(default, "ASDFGHJKL", 50.00, "2022-11-05");

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

insert into tb_aero (idAero, nomeAero, cidadeAero, ufAero) values ('GRU', 'Aeroporto Internacional de Guarulhos', 'Guarulhos', 'SP'),
('MAO', 'Aeroporto Internacional de Manaus', 'Manaus', 'AM'),
('SSA', 'Aeroporto Internacional de Salvador', 'Salvador', 'BA'),
('DIA', 'Aeroporto Internacional de Doha', 'Doha', null),
('CMN', 'Aeroporto Internacional Mohammed V', 'Casablanca', ''),
('NAT', 'Aeroporto Internacional de Natal', 'Natal', 'RN'),
('GIG', 'Aeroporto Internacional do Galeão', 'Rio de Janeiro', 'RJ'),
('JOI', 'Aeroporto de Joinville', 'Joinville', 'SC'),
('CWB', 'Aeroporto Internacional de Curitiba', 'Curitiba', 'PR'),
('IGU', 'Aeroporto Internacional de Foz do Iguaçu', 'Foz do Iguaçu', 'PR'),
('FLN', 'Aeroporto Internacional de Florianópolis', 'Florianópolis', 'SC'),
('ORD', "Aeroporto Internacional O'Hare", 'Chicago', null);


-- Cadastrar funcionário
drop procedure if exists spInsertFunc;
DELIMITER $$
CREATE PROCEDURE spInsertFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vLoginFunc varchar(100), vTelefoneFunc char(11), vSenhaFunc varchar(100)) 

BEGIN
	INSERT INTO tb_funcionario (CPFFuncionario, NomeFuncionario, NomeSocialFuncionario, LoginFuncionario, TelefoneFuncionario, SenhaFuncionario) VALUES (vCpfFunc, vNomeFunc, vNomeSocialFunc, vLoginFunc, vTelefoneFunc, vSenhaFunc);
END $$

DELIMITER $$

-- Cadastrar cliente
drop procedure if exists spInsertCli;
DELIMITER $$
CREATE PROCEDURE spInsertCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vLoginCliente varchar(100), vTelefoneCli char(16), vSenhaCli varchar(100)) 

BEGIN
	INSERT INTO tb_cliente (CPFCliente, NomeCliente, NomeSocialCliente, LoginCliente, TelefoneCliente, SenhaCliente) VALUES (vCpfCli, vNomeCli, vNomeSocialCli, vLoginCliente, vTelefoneCli, vSenhaCli);
END $$

DELIMITER $$


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

DELIMITER $$

-- Select login cliente
drop procedure if exists spSelectLoginCli;
DELIMITER $$
CREATE PROCEDURE spSelectLoginCli(vLoginCliente varchar(100))

BEGIN
	select LoginCliente from tb_cliente where LoginCliente = vLoginCliente;
END $$

DELIMITER $$


-- Alterar funcionário 
drop procedure if exists spAlterFunc;
DELIMITER $$
CREATE PROCEDURE spAlterFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vLoginFunc varchar(100), vTelefoneFunc char(11), vSenhaFunc varchar(100)) 

BEGIN
		UPDATE tb_funcionario SET NomeFuncionario = vNomeFunc, NomeSocialFuncionario = vNomeSocialFunc, LoginFuncionario = vLoginFunc, TelefoneFuncionario = vTelefoneFunc, SenhaFuncionario = vSenhaFunc where CPFFuncionario = vCpfFunc;
END $$

DELIMITER $$

-- Alterar cliente
drop procedure if exists spAlterCli;
DELIMITER $$
CREATE PROCEDURE spAlterCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vLoginCliente varchar(100), vTelefoneCli char(11), vSenhaCli varchar(100)) 

BEGIN
		UPDATE tb_cliente SET NomeCliente = vNomeCli, NomeSocialCliente = vNomeSocialCLi, LoginCliente = vLoginCliente, TelefoneCliente = vTelefoneCli, SenhaCliente = vSenhaCli where CPFCliente = vCpfCli;
END $$

DELIMITER $$


-- Alterar senha funcionário
drop procedure if exists spAlterSenhaFunc;
DELIMITER $$
CREATE PROCEDURE spAlterSenhaFunc(vCpfFunc bigint, vSenhaFunc varchar(100))

BEGIN
	UPDATE tb_funcionario set SenhaFuncionario = vSenhaFunc where CPFFuncionario = vCpfFunc;
END $$

DELIMITER $$

-- Alterar senha cliente
drop procedure if exists spAlterSenhaCli;
DELIMITER $$
CREATE PROCEDURE spAlterSenhaCli(vCpfCliente varchar(100), vSenhaCli varchar(100))

BEGIN
	UPDATE tb_cliente set SenhaCliente = vSenhaCli where CPFCliente = vCpfCliente;
END $$

DELIMITER $$


-- Deletar funcionário
drop procedure if exists spDeleteFunc;
DELIMITER $$
CREATE PROCEDURE spDeleteFunc(vCpfFunc bigint)

BEGIN
	DELETE from tb_funcionario where CPFFuncionario = vCpfFunc;
END $$

DELIMITER $$

-- Deletar cliente
drop procedure if exists spDeleteCli;
DELIMITER $$
CREATE PROCEDURE spDeleteCli(vCpfCli bigint)

BEGIN
	DELETE from tb_cliente where CPFCliente = vCpfCli;
END $$

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
CREATE PROCEDURE spInsertCupom(vCupomcode char(9), vValordesconto decimal, vCupomvalidade date)

BEGIN
	insert into tb_cupom (Cupomcode, Valordesconto, Cupomvalidade) values (vCupomcode, vValordesconto, vCupomvalidade);
END $$

DELIMITER $$


-- Alterar cupom
drop procedure if exists spAlterCupom;
DELIMITER $$
CREATE PROCEDURE spAlterCupom(vCupomId int, vCupomcode char(9), vValordesconto decimal, vCupomvalidade date)

BEGIN
	update tb_cupom set CupomCode = vCupomcode, Cupomvalidade = vCupomvalidade, Valordesconto = vValordesconto where CupomId = vCupomId;
END $$


-- Deletar cupom
drop procedure if exists spDeleteCupom;
DELIMITER $$
CREATE PROCEDURE spDeleteCupom(vCupomId int)

BEGIN
	delete from tb_cupom where CupomId = vCupomId;
END $$

DELIMITER $$

/*
NotaFiscal int auto_increment primary key not null,
    DataCompra datetime,
    QtdPassagem int,
    ValorTotal decimal(15,2),
    CPFCliente bigint not null,
    Cupom int,
    CodTipoPagto int,
    IdPassagem int,
*/

drop procedure if exists spInsertPassagem;
DELIMITER $$
CREATE PROCEDURE spInsertPassagem(vNomePassagem varchar(200), vDescPassagem varchar(500), vImgPassagem varchar(100), vValor decimal(15,2),
                 vClasse varchar(50), vCiaAerea varchar(50), vAeroPartida char(3), vAeroDestino char(3), vPartida datetime, vDestino datetime, vDuracao int)

BEGIN
    insert into tb_passagem (idpassagem, nomepassagem, descpassagem, imgpassagem, valorpassagem, idclasse, cnpjciaaerea, idaeropartida, idaerodestino, DtHrChegada, DtHrPartida, DuracaoVoo)
    values (default, vNomePassagem, vDescPassagem,  vImgPassagem, vValor, (SELECT IdClasse from tb_classe where Classe = vClasse limit 1), (SELECT CNPJCiaAerea from tb_ciaAerea where CiaAerea = vCiaAerea limit 1), vAeroPartida, vAeroDestino, vPartida, vDestino, vDuracao);
END $$
						
DELIMITER $$


-- Alterar passagem
drop procedure if exists spAlterPassagem;
DELIMITER $$
CREATE PROCEDURE spAlterPassagem(vIdPassagem int, vNomePassagem varchar(200), vDescPassagem varchar(500), vImgPassagem varchar(100), vValor decimal(15,2), 
				 vClasse varchar(50), vCiaAerea varchar(50), vAeroPartida char(3), vAeroDestino char(3), vPartida datetime, vChegada datetime, vDuracao int)

BEGIN
	update tb_passagem set NomePassagem = vNomePassagem, DescPassagem = vDescPassagem, ImgPassagem = vImgPassagem, ValorPassagem = vValor, 
    IdClasse = (SELECT IdClasse from tb_classe where Classe = vClasse limit 1), CNPJCiaAerea = (SELECT CNPJCiaAerea from tb_ciaAerea where CiaAerea = vCiaAerea limit 1), IdAeroPartida = vAeroPartida, IdAeroDestino = vAeroDestino, DtHrPartida = vPartida, DtHrChegada = vChegada, DuracaoVoo = vDuracao where IdPassagem = vIdPassagem;
END $$

DELIMITER $$


-- Deletar passagem
drop procedure if exists spDeletePassagem;
DELIMITER $$
CREATE PROCEDURE spDeletePassagem(vIdPassagem int)

BEGIN
	delete from tb_passagem where IdPassagem = vIdPassagem;
END $$

DELIMITER $$


-- Insert compra
drop procedure if exists spInsertCompra;
DELIMITER $$
CREATE PROCEDURE spInsertCompra(vData date, vQtd int, vTotal decimal(15,2), vCpfCliente bigint, vCupom char(9), vTipoPagto varchar(30), vIdPassagem int)

BEGIN
	insert into tb_compra (NotaFiscal, DataCompra, QtdPassagem, ValorTotal, CPFCliente, Cupom, CodTipoPagto, IdPassagem)
    values (default, vData, vQtd, vTotal, vCpfCliente, (select CupomId from tb_cupom where CupomCode = vCupom limit 1), (select CodTipoPagto from tb_tipoPagto where TipoPagto = vTipoPagto limit 1), vIdPassagem);
END $$

DELIMITER $$


-- Select compra
drop procedure if exists spSelectCompra;
DELIMITER $$
CREATE PROCEDURE spSelectCompra(vNotaFiscal int)

BEGIN
	select NotaFiscal, DataCompra, ValorTotal, CPFCliente, Cupom, CodTipoPagto from tb_compra where NotaFiscal = vNotaFiscal or DataCompra = vData or CPFCliente = vCpfCliente;
END $$

DELIMITER $$


-- Alterar valor total compra
DELIMITER $$
CREATE PROCEDURE spAlterValorCompra(vNotaFiscal int, vTotal decimal(15,2))

BEGIN
	update tb_compra set ValorTotal = vTotal where NotaFiscal = vNotaFiscal;
END $$

DELIMITER $$


-- Inserir item compra
/*drop procedure if exists spItemCompra;
DELIMITER $$
CREATE PROCEDURE spItemCompra(vNotaFiscal int, vIdPassagem int, vQtd int)

BEGIN
	insert into tb_itemCompra (NotaFiscal, IdPassagem, QtdPassagem) values (vNotaFiscal, vIdPassagem, vQtd);
END $$

DELIMITER $$
*/


-- View listar passagem
drop view if exists vw_passagem;
create view vw_passagem
as select
	p.IdPassagem as IdPassagem,
    p.NomePassagem as NomePassagem,
	p.DescPassagem as DescPassagem,
    p.ImgPassagem as ImgPassagem,
    p.ValorPassagem as ValorPassagem,
	p.DtHrPartida as DtHrPartida,
    p.DtHrChegada as DtHrChegada,
    p.DuracaoVoo as DuracaoVoo,
    ca.CiaAerea as CiaAerea,
    c.Classe as Classe,
    aP.IdAero as IdAeroPartida,
    aD.IdAero as IdAeroDestino,
    aP.NomeAero as NomeAeroPartida,
    aD.NomeAero as NomeAeroDestino,
    aP.CidadeAero as CidadeAeroPartida,
    aD.CidadeAero as CidadeAeroDestino,
    aP.UfAero as UfAeroPartida,
    aD.UfAero as UfAeroDestino
from tb_passagem p	inner join tb_classe as c on p.IdClasse = c.IdClasse
					inner join tb_ciaAerea as ca on p.CNPJCiaAerea = ca.CNPJCiaAerea
                    join tb_aero as aP on aP.IdAero = p.IdAeroPartida
                    join tb_aero as aD on aD.IdAero = p.IdAeroDestino;

select * from vw_passagem;


-- View listar compra
drop view if exists vw_compra;
create view vw_compra
as select
	p.IdPassagem as IdPassagem,
    p.NomePassagem as NomePassagem,
	p.DescPassagem as DescPassagem,
    p.ImgPassagem as ImgPassagem,
    p.ValorPassagem as ValorPassagem,
	p.DtHrPartida as DtHrPartida,
    p.DtHrChegada as DtHrChegada,
    p.DuracaoVoo as DuracaoVoo,
    ca.CiaAerea as CiaAerea,
    c.Classe as Classe,
    aP.IdAero as IdAeroPartida,
    aD.IdAero as IdAeroDestino,
    aP.NomeAero as NomeAeroPartida,
    aD.NomeAero as NomeAeroDestino,
    aP.CidadeAero as CidadeAeroPartida,
    aD.CidadeAero as CidadeAeroDestino,
    aP.UfAero as UfAeroPartida,
    aD.UfAero as UfAeroDestino,
    ic.QtdPassagem as QtdPassagem,
    co.ValorTotal as ValorTotal,
    tp.TipoPagto as TipoPagto
from tb_passagem p	inner join tb_classe as c on p.IdClasse = c.IdClasse
					inner join tb_ciaAerea as ca on p.CNPJCiaAerea = ca.CNPJCiaAerea
                    join tb_aero as aP on aP.IdAero = p.IdAeroPartida
                    join tb_aero as aD on aD.IdAero = p.IdAeroDestino
                    inner join tb_itemCompra as ic on ic.IdPassagem = p.IdPassagem
                    inner join tb_compra as co on co.NotaFiscal = ic.NotaFiscal
                    inner join tb_tipoPagto as tp on tp.CodTipoPagto = co.CodTipoPagto;

select * from vw_compra;

-- Selects simples
select * from tb_funcionario;
select * from tb_cliente;
select * from tb_compra;
select * from tb_classe;
select * from tb_ciaAerea;
select * from tb_passagem;


-- Calls procedures
CALL spInsertFunc(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654"); 
CALL spInsertCli(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "987654"); 
CALL spSelectLoginFunc("brendaberzin@gmail.com");
CALL spSelectLoginCli("brendaberzin@gmail.com");
CALL spAlterFunc(78456377925, "Otávio de Paula", null, "otavio@gmail.com", "11989652235", "odp667");
CALL spAlterCli(57689455721, 'Elio Gaspari', null, 'elio.gaspari@gmail.com', '12976119231', 'eli999');
CALL spAlterSenhaFunc (57345699832, "gjs262");
CALL spAlterSenhaCli (52673833846, "bsb975");
CALL spDeleteFunc(98623688689);
CALL spDeleteCli(78545623745);
call spInsertCupom('KSJCI9JAO', 100, '2022-10-10');
call spAlterCupom(1, 'AABAAAAAA', 100.00, '2022-10-10');
CALL spInsertPassagem("Passagem 1", "Voo direto de Guarulhos para Curitiba", "html//foto", "1250.00", "Classe econômica", "Gol Linhas Aéreas", "GRU", "CWB", "2022-11-25 00:00:00", "2022-11-25 00:00:00", 1);		
CALL spAlterPassagem(1, "Passagem 1", "Voo direto de Guarulhos para Curitiba", "html//foto", "1257.00", "Classe executiva", "Gol Linhas Aéreas", "GRU", "CWB", "2022-11-25 00:00:00", "2022-11-25 00:00:00", 2);
CALL spDeletePassagem(1);
CALL spInsertCompra("2022-11-17", 2, null, 52673833846, null, "Cartão de crédito", 1);
CALL spSelectCompra(2, null, null);
CALL spAlterValorCompra(2, "1256.00");
-- CALL spItemCompra(2, 1, 2);
