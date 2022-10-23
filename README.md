# APIs para um sistema de ATS

API Web com o ASP.NET Core 6.0 com MongoDB de CRUD de candidatos e vagas para um sistema de ATS.

**Pré-requisito**
Ter o MongoDB instalado. A API se conecta ao MongoDB através da porta padrão **27017**. Caso o MongoDB utilize outra porta, altere o arquivo **appsettings.json**, informando a porta na propriedade **"ConnectionString"**.

Para executar a aplicação, abra o projeto no Visual Studio e inicie a execução através do Ctrl + F5. 
Será aberto a janela do Browser com a página do Swagger onde poderá ser testado os Endpoints para o CRUD, mas também é possível utilizar o Postman para efetuar testes.
