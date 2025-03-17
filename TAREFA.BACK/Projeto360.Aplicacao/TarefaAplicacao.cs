using Projeto360.Dominio.Entidades;
using Projeto360.Servicos.Interface;

namespace Projeto360.Aplicacao
{
    public class TarefaAplicacao : ITarefaAplicacao
    {
        private readonly IJsonPlaceHolderServico _jsonPlaceHolderServico;

        public TarefaAplicacao(IJsonPlaceHolderServico jsonPlaceHolderServico)
        {
            _jsonPlaceHolderServico = jsonPlaceHolderServico;
        }

        public async Task<List<Tarefa>> ListarTarefasAsync()
        {
            return await _jsonPlaceHolderServico.ListarTarefas();
        }
    }
}