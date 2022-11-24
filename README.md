# CINEMA WEB APPLICATION

Um projeto criado para controle de filmes e sessões de um cinema.

## Funcionalidades

- Login com autenticação JWt.
- Cadastrar, editar e remover filmes.
- Visualização de salas.
- Cadastrar e remover sessões.
- Sessões vinculadas aos filmes.
- Upload de Imagens.

## Instalação

Clone o projeto

```bash
  git clone https://github.com/AndreyPlusVieira/CinemaWebApp.git
```

Entre no diretório do projeto

```bash
  cd CinemaPrintWayy
```

Instale as dependências

```bash
  npm install
```

### Configurando Banco de dados SQL Server

Na raiz do projeto va para a pasta WebAPI

```bash
  cd WebAPI
```

Em appsettings.json vamos alterar nossa "ConnectionStrings" para o caminho do banco de dados da sua maquina.

```bash
 {
  "ConnectionStrings": {
    "DefaultConnection": "Sua Conexão."
  },
```

Na raiz do projeto va para a pasta WebAPI

```bash
  cd Infrastructure/Configuration/ContextBase.cs
```

no Metodo GetConnectionString(), tambem vamos colocar a Conexão.

```bash
 public string GetConnectionString()
        {
            return "Sua Conexão.";
        }
```

Na pasta raiz vamos para a pasta WebAPI

```bash
cd WebAPI
```

abrir o terminal e executar o comando

```bash
dotnet ef database update
```

## Configurando e Rodando localmente

Vamos abrir o terminal na pasta da API

```bash
  cd WebAPI
```

e vamos rodar a aplicação com o comando

```bash
  dotnet run
```

entramos no endereço

```bash
  https://localhost:7116/swagger/index.html
```

Dentro da API vamos na parte de USERS e utilizaremos o caminho /api/AddUserIdentity

```bash
{
"email": "Usuário Desejado",
"senha": "Senha Desejada"
}
```

Na raiz do projeto vamos para a pasta CinemaPrintWayy no terminal

```bash
  cd CinemaPrintWayy
```

Utilizaremos o comando

```bash
  ng s -o
```

Agora utilizando o usuario que criamos estamos aptos a navegar na aplicação.

## Autores

- [@AndreyPlusVieira](https://github.com/AndreyPlusVieira) (github).
- [@andrey-vieira](https://www.linkedin.com/in/andrey-vieira/) (linkedin).
