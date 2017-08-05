Prova de Back-End
===============

Apresentação
----------------

A prova consiste na alteração do projeto contido nesse repositório, ele contém uma área de notícias, onde uma notícia tem uma categoria, e vários itens podendo ser um texto ou uma imagem.

O projeto é a alteração do template básico do asp.net utilizando autenticação individual.

Foi utilizado o Entity Framework, usando com a abordagem [Code Frist][1], para criação do banco e dos controles básicos via o scaffolding padrão.

O objetivo geral da prova é mostrar as atribuições básicas do dia a dia lembrando que todos os problemas foram simplificados para maior facilidade. 

----------



Parte 1
-------------

Alteração do projeto existente.

 1. Alterar o controle de listagem notícias para que as mesmas sejam ordenadas por ordem alfabética de título.
 2. Alterar a ação de criação do controle de notícias para que indiferente a URL que seja digitada pelo usuário ela seja salva de acordo com o título, retirando a acentuação, trocando os espaços por underline e deixando todos os caracteres minúsculos (Notícia 1 > noticia_1 ).
 3. Criação de uma nova rota, onde o padrão seja /Noticia/Categoria/URL, e a ação onde retorne a uma qualquer notícia da Categoria com a URL digitada.
 4. Alterar a ação de criação controle de notícias para que somente o usuário com role de administrador consiga acessar a ação (Não precisa informar o usuário que ele não tem permissão)
 
Parte 2
-------

Criação de uma nova área utilizando o Entity Framework [Code Frist][1], montar os modelos e gerar os controles com as ações de CRUD.

> Um atendimento possui um e somente um paciente, possui um tipo e somente um tipo, possui um código único que o identifica, possui uma data de início e fim onde a data fim é opcional, também possui um convenio e possui várias contas.
> 
>O paciente possui um nome, um código identificador, uma data de nascimento e um documento com número único (Não é necessário ser um RG ou CPF, somente um valor numérico único) 
>
> Os tipos são fixos, são Internação, Urgência, Externo e Ambulatorial
> 
> O convenio possui um código único, um nome e um indicador se está ativo ou não.
> 
> Uma conta possui um código único, somente um atendimento, data de início e data fim, sendo o fim opcional, um valor total maior ou igual a zero e um indicador se a conta está fechada ou não.

Criação ou alteração dos dados de teste
=======

Caso os dados de testes forem alterados ou gerados mais lembrar que o banco utilizado é local, para que seja corrigido com os novos dados alterar o método seed da classe de configuração das migrações.

Considerações gerais
=======

O projeto deve ser entregue até as 18:00 do dia 14/08/2017, poderá ser enviado por [wetransfer][2] ou ferramenta semelhante, para o e-mail gabriel.ferreira@santacasasaocarlos.com.br ou preferencialmente criar um repositório pulico no [GitHub][3] ou semelhante e o envio do link do repositório no e-mail gabriel.ferreira@santacasasaocarlos.com.br.

Para qualquer dúvida, até mesmo em problemas ao tentar resolver as questões também entrar em contato que assim que possível será enviado algum material de apoio ou algum feedback sobre o problema apontado, também no mesmo e-mail gabriel.ferreira@santacasasaocarlos.com.br ou pelo WhatsApp +5515981301205 porem somente por mensagem ou imagens, para facilitar a documentação, lembrando que isso será positivo, pois o trabalho em equipe é fundamental.

Desejo a todos, boa sorte!

E estou ansioso para conhecê-los

[1]:https://msdn.microsoft.com/pt-br/library/hh972463.aspx
[2]:https://wetransfer.com/
[3]:https://github.com/