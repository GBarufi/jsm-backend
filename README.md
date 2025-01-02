# Code Challenge JSM
Projeto referente ao Code Challenge da Juntos Somos Mais.<br/>
Este protótipo faz uso de uma *In-Memory Database*, portanto nenhuma configuração prévia é necessária. Basta clonar a aplicação e executá-la.
<br/>
<br/>

## Funcionamento
Durante a inicialização da aplicação, é executado um *HostedService* que efetua a requisição para recuperar o CSV e o JSON.
<br/>
<br/>
A aplicação implementa o padrão CQRS, recebendo solicitações através de *commands* e *queries* e efetuando o processamento através de seus respectivos *handlers*.
Sendo assim, os dados do CSV e do JSON são lidos através da execução de um *command*, armazenados em uma base em memória, e então podem ser lidos através de uma *query*, aplicando os filtros desejados.
<br/>
<br/>

## Principais bibliotecas
- CSVHelper para a leitura de arquivos CSV;<br/>
- Newtonsoft.Json para a desserialização de arquivos JSON;<br/>
- MediatR para implementação de um *mediator*;
- FluentValidation para a validação dos *commands* durante as requisições;<br/>
- XUnit, Moq e Bogus para os testes unitários;
<br/>

## Endpoints
Após a conclusão das requisições iniciais, a API segue disponibilizando a criação de novos usuários. Basta efetuar um POST em "/users".
<br/>
<br/>
Já para a leitura dos usuários, basta efetuar um GET em "/users". Os filtros disponíveis são:
- Nome do usuário, podendo este ser o primeiro nome ou o sobrenome;
- Região (Como a aplicação está toda em inglês, as opções de filtro são "North", "Northeast", "Midwest", "Southeast" e "South");
- Estado (Usar a abreviação, exemplo "SP");
- Cidade;
- Tipo (Conforme descrito nas orientações do teste, os tipos disponíveis são "Special", "Normal", "Hard"* e "Laborious");
<br/>
Além destes, é possível também paginar os resultados através dos parâmetros "pageNumber" e "pageSize".<br/>
Para mais informações, acessar a página do Swagger da API.
<br/>
<br/>

## Observações
\* As orientações do teste descrevem quais devem ser os tipos de usuários de acordo com as coordenadas, porém em um deles são exibidas as coordenadas sem nenhuma descrição. Para este caso, assumi o tipo "Hard".
<br/>

