using Microsoft.AspNetCore.Mvc;
using Projeto360.Api.Models.Tarefas.Resposta;
using Projeto360.Aplicacao;

namespace Projeto360.Api
{
    [ApiController]
    [Route("[Controller]")]
    public class TarefaController: ControllerBase
    {
        private readonly ITarefaAplicacao _tarefaAplicacao;

        public TarefaController(ITarefaAplicacao tarefaAplicacao)
        {
            _tarefaAplicacao = tarefaAplicacao;
        }

        [HttpGet]
        [Route("Listar")]

        public async Task<ActionResult> ListarAsync(){
            var tarefas = await _tarefaAplicacao.ListarTarefasAsync();
            
            var tarefasResposta = tarefas.Select(tarefa => new TarefaResposta
                {
                    ID = tarefa.ID,
                    Nome = tarefa.Nome,
                    Completa = tarefa.Completa
                }
            );
            return Ok(tarefasResposta);

        }
    }
}