# ProjetoFinal-CodingGirls

Escopo:

Objetivo: Desenvolver uma web API que nos permita gerenciar os alunos de uma instituição de ensino.
Nome do banco: escola
Tabelas existentes: aluno e turma.
Descrição do relacionamento: uma turma pode conter vários alunos, porém, um aluno só pode estar vinculado a uma turma. 

Link da Web API na Azure: https://apigerenciamentodeensino20220703234102.azurewebsites.net

Funcionalidades:

ConsultarTodas as turmas(GET):https://apigerenciamentodeensino20220703234102.azurewebsites.net /api/Turma

Consultar todos os Alunos(GET): https://apigerenciamentodeensino20220703234102.azurewebsites.net /api/Aluno

Já os demais métodos devem ser acessados via Postman.

Consultar Turma por id (GET):https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Turma/1

Atualizar Turmas (PUT):https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Turma/1

Incluir Turma (POST):https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Turma

Deletar Turma(DELETE): https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Turma/1

Consultar Aluno por id(GET): https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Aluno/1

Atualizar Alunos (PUT): https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Aluno/1

Incluir Alunos(Post):https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Aluno

Deletar Alunos(DELETE): https://apigerenciamentodeensino20220703234102.azurewebsites.net/api/Aluno/2

Requisitos:

Um aluno não pode ser incluído sem uma turma-->Relacionamento 1 aluno: 1turma

Uma turma só pode ser excluída se não tiverem alunos cadastrados nela-->Filtro na controller delete de Turmas verificando se a turma tem ou não alunos para que possa ser excluida.

Um aluno pode ser movido de turma-->Conroller Put de Alunos.

A consulta por turmas e alunos deve obedecer uma regra que é: só retornar alunos cuja condição é ativa(o)-->Filtro na controller Get de turmas para retornar somente as turmas ativas.

Atenciosamente Thaís Oliveira.
