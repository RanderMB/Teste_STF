# Descrição Pojeto
CRUD para as tabelas "Pedido", "ItensPedido", "Produto".

## Requerimentos Para Utilizar
- .NET 6;
- Visual Studio 2022;

## Como Utilizar
- Copie meu código e dê gitclone em algum diretóro de sua preferência em sua maquina.
Abra o arquivo "CrudProduto.csproj.user".

- No terminal, insira o comando a seguir para rodar a migration "dotnet ef update database". 
Em seguida rode a aplicação e adcione à URL o seguinte: "/swagger".

Para se fazer requisições de Pedido, deve-se primeiramente Adcionar (requisitar um POST) ao menos 1 Produto.
O JSON de response de Pedido contém o array de ItensPedido, onde há a coluna de FK da tabela Produto.

Após adcionar minimo de 1 produto, é so fazer as requisições que se deseja.


