# Descrição Do Projeto
CRUD para as tabelas "Pedido", "ItensPedido", "Produto".

## Requerimentos Para Utilizar
- .NET 6;
- Visual Studio 2022;

## Como Utilizar
- Copie meu código e dê gitclone em algum diretóro de sua preferência em sua maquina.
Abra o arquivo "CrudProduto.sln".

- No terminal, insira o comando a seguir para rodar a migration "dotnet ef database update". 
- Caso não funcione, verifique se os NuGet do EF estão instalados.
- São eles: dotnet tool install --global dotnet-ef // dotnet tool update --global dotnet-ef // dotnet add package Microsoft.EntityFrameworkCore.Design

-Em seguida rode a aplicação e adcione à URL o seguinte: "/swagger".

Para se fazer requisições de Pedido, deve-se primeiramente Adcionar (requisitar um POST) ao menos 1 Produto.
O JSON de response de Pedido contém o array de ItensPedido, onde há a um FK da tabela Produto.

Após adcionar minimo de 1 produto, faça um post de pedido utilizando o ID do produto adcionado que se deseja listar em pedido.

## Observação para avaliação
O código utiliza o SQLite por questão de pertinencia dos dados.


