# PlanoContasApi


Projeto Está gravando inicialmente apenas em memoria, dessa maneira a cada finalização do projeto está sendo perdido os dados.

Irei deixar alguns payloads, para que ja grave alguns dados diretamente para poder iniciar os testes. Tudo pode ser testado pelo SWAGGER.



--------- Payloads Possiveis de testes ------------

1 - Cadastrar Os tipos, payload abaixo, caso não exista algum tipo cadastrado o sistema não deixará cadastrar. Estou deixando um payload duplo para que possa ja ter 2 objetos para cadastro para testes.

Payload Ex:
[
{
  "descricao": "Receitas"
},
{
  "descricao": "Despesa"
}
]


2 - Para cadastrar algum Lancamento usar endpoint o Cadastrar Conta.
Payload Ex:

{
  "descricao": "Receita",
  "tipo": 1,
  "aceitaLancamentos": false
}

3 - Para cadastrar qualquer sublancamento para cada antes é interessante fazer o fluxo de buscar o proximoCodigo, pelo endpoint "RetornarProximoCodigo", para poder inserir um valido.
