LibManage
LibManage é um sistema de gerenciamento de biblioteca desenvolvido em ASP.NET, projetado para gerenciar eficientemente livros, usuários, empréstimos e multas. O sistema permite que os administradores acompanhem a disponibilidade de livros, gerenciem empréstimos, usuários e monitorem multas por atrasos na devolução.

Funcionalidades
Gerenciamento de Usuários: Criar, atualizar e gerenciar usuários da biblioteca (alunos, professores).
Gerenciamento de Livros: Adicionar, atualizar e remover livros, visualizar a disponibilidade.
Gerenciamento de Empréstimos: Controlar empréstimos de livros, devoluções e atrasos.
Gerenciamento de Multas: Calcular e monitorar automaticamente as multas por devoluções atrasadas.
Tecnologias Utilizadas
ASP.NET Core para o desenvolvimento do backend
Entity Framework Core para o gerenciamento do banco de dados
SQL Server como banco de dados
Bootstrap para a interface responsiva
JavaScript (opcional) para interatividade no front-end
Começando
Pré-requisitos
Antes de rodar o projeto, certifique-se de ter os seguintes itens instalados:

.NET SDK
SQL Server ou outro banco de dados compatível
Visual Studio (recomendado para facilitar o desenvolvimento e depuração)
Instalação
Clone o Repositório:

bash
Copiar código
git clone https://github.com/seu-usuario/libmanage.git
cd libmanage
Configurar o Banco de Dados:

Abra o arquivo appsettings.json e configure a string de conexão do banco de dados para o SQL Server.
Execute os seguintes comandos para criar e aplicar as migrações:
bash
Copiar código
dotnet ef migrations add InitialCreate
dotnet ef database update
Rodar o Projeto: Após configurar o banco de dados, você pode iniciar a aplicação com o seguinte comando:

bash
Copiar código
dotnet run
Acessar o Sistema: Acesse o sistema através do navegador na seguinte URL:

arduino
Copiar código
http://localhost:5000
