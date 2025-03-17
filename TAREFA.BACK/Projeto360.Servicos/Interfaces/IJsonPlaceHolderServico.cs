using Projeto360.Dominio.Entidades;


namespace Projeto360.Servicos.Interface 
{
    public interface IJsonPlaceHolderServico
    {
        Task<List<Tarefa>> ListarTarefas();
    }
}