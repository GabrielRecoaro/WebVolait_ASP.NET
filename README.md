
# Volait Linhas Aéreas

Sistema ASP.NET MVC voltado a empresa "Volait", agência de viagens



## Funcionalidades

- Cadastrar clientes, funcionários e passagens;
- Venda e exibição de passagens;
- Catálogo informativo.



## Autores

- [@gabrielrecoaro](https://github.com/gabrielrecoaro)
- [@otaviodepaula](https://github.com/otaviodepaula)
- [@brendaberzin](https://github.com/brendaberzin)
- [@brnbastos](https://github.com/brnbastos)
- [@pedroaugusto](https://github.com/pedroaugusto90)
- [@thgalvao](https://github.com/thgalvao)


## FAQ

#### Qual foi a motivação para a criação do sistema?

Este sistema tem como finalidade incoporar os conhecimentos e conceitos aprendidos ao longo de três anos de curso de Desenvolvimento de Sistemas.

#### Quais são os as missões e visões estabelecidos na empresa?

- Missão: Atender e auxiliar aventureiros ao redor do mundo, conectando a emoção de uma viagem a um emocionado viajante.

- Visão: Realizar com proeficiência sua função e tornar-se prioridade na nossa lista de clientes.

#### Como posso visitar o sistema?

O sistema encontra-se offline no momento, porém sua utilização é possível através do download deste repositório.
Antes de iniciar, certifique-se de alterar a senha da connection string no item "WebConfig" para a senha respectiva do MySqlWorkBench da sua máquina. Caso ocorra algum erro relacionado ás referências do arquivo, siga o seguinte procedimento:

- Botão direito em Solução 'WebVolait' > Restaurar Pacotes NuGet > Abra o arquivo referências > Exclua a referência 'MySqlData' > Botão direito na pasta 'referências' > Adicione novamente o MySqlData

#### Como posso consultar as viagens e valores das passagens

O sistema apresenta níveis de acesso previamente estabelecidos. Portanto, sua utilização pode ser diferente dependendo da hierarquia do usuário.

Para o cliente: O sistema concentra-se na página inicial "Home", onde de começo os destaques da semana já são apresentados para que o usuário possa acessá-los. Caso haja o interesse por alguma das passagens disponíveis, o cliente poderá realizar o seu cadastro no canto superior direito da página. Realizado o cadastro, o cliente se torna capaz de realizar uma nova compra utilizando o seu CPF. Para acessar o menu de compras, o cabeçalho disponibiliza uma área que permite iniciar o processo. Com os dados cadastrados e verificados, uma nota fiscal é emitida e todos os dados da passagem adquirida são exibidos novamente.

Para o funcionário: Já cadastrado no sistema através do banco de dados (login = 'adm', senha = '123456'), o funcionário inicial é possibilitado de realizar o seu login no canto superior direito da página logo ao lado do "Cadastro de cliente". Todas as funcionalidades já mencionadas para o cliente também são disponíveis para o funcionário, todavia, quando logado no sistema, o usuário poderá acessar áreas de gerenciamento exclusivas, como por exemplo "Listar Clientes", "Listar Funcionários", "Listar Cupons" e "Listar Passagens". Todas essas com funções de Inserir, Alterar e Excluir dados. 
