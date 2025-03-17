using Projeto360.Dominio.Entidades;

namespace Projeto360.Aplicacao
{
    public interface ITarefaAplicacao
    {
        Task<List<Tarefa>> ListarTarefasAsync();
    }
}