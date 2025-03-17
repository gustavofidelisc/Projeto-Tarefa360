using Projeto360.Dominio.Entidades;

public interface IUsuarioRepositorio
{
    public Task AtualizarAsync(Usuario usuario);
    public Task<IEnumerable<Usuario>> ListarAsync(bool ativo);

    public Task<Usuario> ObterAsync(int usuarioId);

    public Task<Usuario> ObterUsuarioDesativadoAsync(int usuarioId);

    public Task<Usuario> ObterPeloEmailAsync(string email);

    public Task<int> SalvarAsync(Usuario usuario);
}