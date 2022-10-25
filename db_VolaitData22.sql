drop database db_VolaitData;
create database db_VolaitData;
use db_VolaitData;

create table tb_funcaoFunc
(
	Id_Funcao int primary key not null auto_increment,
    Funcao_Func varchar(50)
);

create table tb_funcionario
(
	CPF_Func bigint primary key not null,
    NomeCompleto_Func varchar(100) not null,
    NomeSocial_Func varchar(100) null,
    Email_Func varchar(100) not null,
    Telefone_Func varchar(11) not null,
    Senha_Func char(6) not null,
    Id_Funcao int,
    constraint fk_funcao foreign key(Id_Funcao) references tb_funcaoFunc(Id_Funcao)
);

create table tb_cliente
(
	CPF_Cli bigint primary key not null,
    NomeCompleto_Cli varchar(100) not null,
    NomeSocial_Cli varchar(100) null,
    Email_Cli varchar(70) not null,
    Telefone_Cli varchar(11) not null,
    Senha_Cli char(6)
);

create table tb_tipoPagto
(
	Cod_TipoPagto int primary key not null auto_increment,
    Tipo_Pagto varchar(30)
);

create table tb_compra
(
	NotaFiscal bigint primary key not null,
    Data_Compra date,
    ValorTotal decimal(15,2),
    CPF_Cli bigint not null,
    Cod_TipoPagto int not null auto_increment,
    constraint fk_cpfCli foreign key(CPF_Cli) references tb_cliente(CPF_Cli),
    constraint fk_tipoPagto foreign key(Cod_TipoPagto) references tb_tipoPagto(Cod_TipoPagto)
);

create table tb_classeVoo
(
	Id_Classe int primary key not null,
    Classe varchar(50) not null
);

create table tb_ciaAerea
(
	CNPJ_CiaAerea int primary key not null,
    CiaAerea varchar(50) not null
);

create table tb_local
(
	Id_Local int primary key not null,
    CidadeAero varchar(50) not null,
    UfAero char(2)
);

create table tb_aero
(
	Id_Aero char(3) primary key not null,
    Id_Local int,
    constraint fk_local foreign key(Id_Local) references tb_local(Id_Local)
);

create table tb_passagem
(
	Id_Passagem int primary key not null auto_increment,
    Nome_Passagem varchar(200) not null,
    Desc_Passagem varchar(500) not null,
    Img_Passagem blob,
    Valor_Passagem decimal(15,2),
    Id_Classe int,
    Id_AeroPartida char(3),
    Id_AeroDestino char(3),
    constraint fk_classe foreign key(Id_Classe) references tb_classeVoo(Id_Classe),
	constraint fk_aeroPartida foreign key(Id_AeroPartida) references tb_aero(Id_Aero),
    constraint fk_aeroDestino foreign key(Id_AeroDestino) references tb_aero(Id_Aero)
);

create table tb_voo
(
	Id_Voo int primary key not null,
    DtHrPartida datetime not null,
    DtHrChegada datetime not null,
    Id_AeroPartida char(3),
    Id_AeroDestino char(3),
    Duracao_Voo int not null,
    CNPJ_CiaAerea int,
    Id_Passagem int,
    constraint fk_ciaAerea foreign key(CNPJ_CiaAerea) references tb_ciaAerea(CNPJ_CiaAerea),
    constraint fk_aeroPartida foreign key(Id_AeroPartida) references tb_aero(Id_Aero),
    constraint fk_aeroDestino foreign key(Id_AeroDestino) references tb_aero(Id_Aero)
);


create table tb_itemCompra
(
    NotaFiscal bigint not null,
    Id_Passagem int,
    Qtd_ItemCompra int,
    constraint fk_passagem foreign key(Id_Passagem) references tb_passagem(Id_Passagem),
    constraint fk_nota foreign key(NotaFiscal) references tb_compra(NotaFiscal)
);

create table tb_cupom
(
	Cupom int not null primary key,
    Desc_Cupom varchar(100),
    ValorDesconto decimal(15,2)
);

insert into tb_funcionario values('52673833846', 'Brenda Sanches Berzin', 'Brenda', 'brenda.berzin@etec.sp.gov.br', '11942786165', 'bsb137');
select * from tb_funcionario;

insert into tb_funcionario values('98623688689', 'Bruno Silva Bastos', 'Bruno', 'bruno.bastos3@etec.sp.gov.br', '11956383957', 'bsb398'),
('57345699832', 'Gabriel Jard Recoaro Silva', 'Gabriel', 'gabriel.silva2615@etec.sp.gov.br', '11944485007', 'gjs261'),
('78456377925', 'Filipe Ferreiro Pereira', 'Filipe', 'felipe.pereira252@etec.sp.gov.br', '11989652235', 'ffp252'),
('56487933278', 'Pedro Augusto Souza Ribeiro de Aquino', 'Pedro Augusto', 'pedro.aquino@etec.sp.gov.br', '11977188102', 'paa564');


insert into tb_cliente values('65789577234', 'Judith Brito', 'Judith', 'jud.brito@gmail.com', '11947265184'),
('57689455721', 'Elio Gaspari', 'Elio', 'elio.gaspari@gmail.com', '11976119231'),
('90834677903', 'Anna Almeida', 'Anna', 'annaalmeida@gmail.com', '11971694278'),
('96745372198', 'Igor Resende', 'Igor', 'igosende@gmail.com', '11989762241'),
('78545623745', 'Laura Goes', 'Laura', 'laura.goes@gmail.com', '11987619433');

insert into tb_tipopagto values(Default, 'Cartão de Crédito'), (Default, 'Cartão de Débito'), (Default, 'Cheque'), (Default, 'Boleto Bancário'), (Default, 'PIX');
select * from tb_tipopagto;

-- Cadastrar funcionário
drop procedure spInsertFunc;
DELIMITER $$
CREATE PROCEDURE spInsertFunc(vCpfFunc bigint, vNomeFunc varchar(100), vNomeSocialFunc varchar(100), vEmailFunc varchar(100), vTelefoneFunc char(11), vLoginFunc varchar(50), vSenhaFunc char(6), vFuncaoFunc varchar(50)) 

BEGIN
	INSERT INTO tb_funcionario (CPF_Func, NomeCompleto_Func, NomeSocial_Func, Email_Func, Telefone_Func, Login_Func, Senha_Func, Funcao_Func) VALUES (vCpfFunc, vNomeFunc, vNomeSocialFunc, vEmailFunc, vTelefoneFunc, vLoginFunc, vSenhaFunc, vFuncaoFunc);
END $$

CALL spInsertFunc(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "brendaberzin@gmail.com", "987654", "Funcionário"); 

-- Cadastrar cliente
drop procedure spInsertCli;
DELIMITER $$
CREATE PROCEDURE spInsertCli(vCpfCli bigint, vNomeCli varchar(100), vNomeSocialCli varchar(100), vEmailFunc varchar(100), vTelefoneFunc char(11), vLoginFunc varchar(50), vSenhaFunc char(6), vFuncaoFunc varchar(50)) 

BEGIN
	INSERT INTO tb_funcionario (CPF_Func, NomeCompleto_Func, NomeSocial_Func, Email_Func, Telefone_Func, Login_Func, Senha_Func, Funcao_Func) VALUES (vCpfFunc, vNomeFunc, vNomeSocialFunc, vEmailFunc, vTelefoneFunc, vLoginFunc, vSenhaFunc, vFuncaoFunc);
END $$

CALL spInsertFunc(52673833846, "Brenda Berzin", null, "brendaberzin@gmail.com", "11942786165", "brendaberzin@gmail.com", "987654", "Funcionário"); 


drop view if exists vw_compra;
create view vw_compra
as select
	tb_compra.NotaFiscal,
    tb_compra.Data_Venda,
    tb_compra.ValorTotal,
    tb_itemCompra.Qtd_ItemCompra,
    tb_cliente.NomeCompleto_Cli,
    tb_cliente.CPF_Cli,
    tb_tipopagto.Tipo_Pagto,
	tb_passagem.Id_Passagem,
    tb_passagem.Nome_Passagem,
    tb_voo.Valor_Voo
from tb_compra  inner join tb_itemcompra on tb_compra.NotaFiscal = tb_itemcompra.NotaFiscal 
				inner join tb_itemcompra on tb_passagem.Id_Passagem = tb_itemcompra.Id_Passagem
                inner join tb_cliente on tb_compra.CPF_Cli = tb_cliente.CPF_Cli
                inner join tb_tipopagto on tb_compra.Cod_TipoPagto = tb_tipopagto.Cod_TipoPagto
                inner join tb_passagem on tb_voo.Id_Voo = tb_passagem.Id_Voo;
              
use db_VolaitData;

drop view if exists vw_passagem;
create view vw_passagem
as select
	tb_passagem.Id_Passagem,
    tb_passagem.Nome_Passagem,
	tb_passagem.Desc_Passagem,
    tb_passagem.Partida_Passagem,
    tb_passagem.Destino_Passagem,
    tb_passagem.Img_Passagem,
    tb_ciaAerea.CiaAerea,
    tb_classe.Id_Classe,
    tb_voo.Id_Voo,
    tb_aero.Id_Aero,
    tb_local.Id_Local,
    tb_local.CidadeAero,
    tb_Local.UfAero,
    tb_voo.DtHrPartida,
    tb_voo.DtHrChegada,
    tb_voo.Escala_Voo,
    tb_voo.DescEscala,
    tb_voo.Valor_Voo,
    tb_voo.QtdDisp_Voo
from tb_passagem  	inner join tb_passagem on tb_voo.Id_Voo = tb_passagem.Id_Voo
					inner join tb_classe on tb_passagem.Id_Classe = tb_classe.Id_Classe
					inner join tb_ciaAerea on tb_voo.CNPJ_CiaAerea = tb_ciaAerea.CNPJ_CiaAerea
                    inner join tb_passagem on tb_aero.Id_Aero = tb_passagem.Id_Aero
                    inner join tb_aero on tb_local.Id_Local = tb_aero.Id_Local;

              
select * from vw_compra;
              
select * from vw_passagem;

 CREATE USER 'adm'@'localhost' IDENTIFIED WITH mysql_native_password BY '12345';
 GRANT ALL PRIVILEGES ON db_VolaitData.* TO 'adm'@'localhost' WITH GRANT OPTION;