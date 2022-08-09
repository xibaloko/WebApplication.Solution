# GTI SOLUTION PROJECT -

*INSTRUÇÕES DE CONFIGURAÇÃO*

***BANCO DE DADOS***

-Abra o arquivo "CreateDatabase.sql" dentro da pasta "DatabaseScript" e rode em uma página de consulta dentro do SqlServer.

***CONNECTION STRING***

-Dentro do projeto lib "Business" abra e edite a classe DbSession, adicione a connection string do seu banco no construtor da classe.

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183556291-657af608-e237-4ad2-9520-cefe548e0da2.png)

***URL WEBAPI***

-Compile e rode o projeto WEBAPI pela primeira vez

-Acesse as propriedades do projeto WEBAPI e copie a Url do projeto

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183556983-709c9be3-1eae-47f9-8041-a8a3d030d2ed.png)

-Dentro do projeto WebMVC, abra o Web.config e substitua a raiz da key API pela Url que você acabou de copiar.

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183557745-7156dba3-0f95-4b80-881d-0009d1bab26a.png)

***WCF***

-Compile e rode o projeto WCFServiceHost pela primeira vez

-Dentro do projeto WebForm, clique com o botão invertido no item "Connected Services" e depois em "Adicionar Referência de Serviço".

-Clique em descobrir e renomeie o namespace para "GtiService"

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183558474-271ef28b-6155-453f-ad35-36c034331ea3.png)

-Ainda dentro de "Adicionar Referência de Serviço", clique em avançado e mude o tipo de coleção para "System.Collections.Generic.List", em seguida clique em ok nas duas janelas.

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183558736-4185143d-067b-421a-9f9f-6431a5ef6ecf.png)

***RUN***

Depois de configurar o ambiente, selecione na solution os projetos que você quer executar.

Ex.:

![image](https://user-images.githubusercontent.com/49794992/183558961-6f8bc264-9b9b-4405-9072-d0a789e90b10.png)




