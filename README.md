# TodoListt
Repositório do treinamento de .NET 
![image](https://github.com/NeitF/TodoListt/assets/104946940/8d85f191-fdab-4a64-8615-2961f5adabe2)
![image](https://github.com/NeitF/TodoListt/assets/104946940/72f82ad6-a5b3-4f24-8570-c1d35c4aa4a0)

## 📖 Sobre

TodoList é uma aplicação para gerenciar suas tarefas pendentes. A partir de uma interface em console simples é possível registrar suas atividades e marcá-las como completas. Desenvolvido utilizando .NET 6, Entity Framework Core e MySql

## 🧱 Esse projeto foi construído com:

- [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
- [MySql](https://www.mysql.com)
- [Entity Framework Core](https://github.com/dotnet/efcore)

## 🚶‍♂️ Instalação e execução

1.  Clone este repositório `git clone https://github.com/NeitF/TodoListt.git`
2.  Entre na pasta da solução: `cd TodoList`
3.  Execute `dotnet restore`
> Se ainda não tem o dotnet instalado, veja o seguinte tutorial [Install .NET on Windows, Linux, and macOS](https://learn.microsoft.com/en-us/dotnet/core/install/)
4.  Garanta que você tenha o Entity Framework Core instalado globalmente `dotnet tool install --global dotnet-ef`
> Se você estiver usando o Linux, talvez precise adicionar o dotnet-ef ao seu PATH.
> Dessa forma:
> ```bash
> sudo nano .bashrc # or sudo nano .zshrc
> # Adicione isso ao final do arquivo
> export PATH="$PATH:$HOME/.dotnet/tools/"
> ```
5. Faça a instalação e configuração do banco de dados MySql <br>
   OBS: O arquivos appsettings.Development.json presentes nos projetos **TodoList.Console** e **TodoList.API** devem ter seu Uid e Pwd na string de conexão modificados caso necessário, de acordo com o usuário do banco de dados que você está utilizando e sua senha
6. Na pasta da solução, execute os seguintes comandos no console: <br>
   `cd .\TodoList.API\`<br>
   `dotnet-ef migrations add EntidadeTodoItem -p ..\TodoList.Core\`<br>
   `dotnet-ef database update`<br>
7.  Execute a API com
```bash
cd .\TodoList.API\
dotnet run
```
Acesse a o swagger pelo link: https://localhost:7139/swagger/index.html
> 8.  Execute a aplicação console com
```bash
cd .\TodoList.Console\
dotnet run
```
