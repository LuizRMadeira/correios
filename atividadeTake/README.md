#Correio San Andres - Luiz Ricardo

A aplicação calcula a menor rota entre duas cidades baseada em uma entrada de dados com os possíveis trechos entre as cidades e o custo da distância entre elas.

Foi implementado algoritimos de inteligência virtual baseado no problema do caixeiro viajante. Por isso, o trechos.txt fornecido é convertido via aplicação em um grafo para podermos manipular os dados durante a utilização da função recursiva nomeada como "permuta", responsável pela permutação dos caminhos identificados.

Foi criado um método que imprime o grafo no console para melhor entendimento do conceito e que também foi muito útil durante a construção da aplicação, ajudando a identificar problemas e podendo imaginar os cenários no momento da construção da função "permuta".
Para o grafo não ser exibido, basta comentar a chamada do método "imprimeGrafo" linha 52 do arquivo Entrega.cs.

Foi simulado um serviço TrechosServico que seria o responsável pela leitura dos trechos.

- O projeto foi desenvolvido no tipo console em C# utilizando o Visual Code version 1.45.1.
- Sistema operacional Windows 10 Pro.
- Framework utilizado para os testes foi o XUnit.
- Utilizado também o framework Moq para o mock dos testes, para não revelar os valores reais ou até mesmo não comprometer o teste da aplicação e não depender do serviço TrechosServicos.

A aplicação é executada de modo simples ao pressionar a tecla F5.
Para executar os testes basta executar o comando "dotnet test" ou na própria classe RotaTests em RunTest.


Luiz Ricardo Madeira
rickyluiz@gmail.com