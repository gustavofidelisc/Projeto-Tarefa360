using Projeto360.Dominio.Entidades;

namespace Projeto360.Dominio
{
    public interface IUsuarioAplicacao
    {
        
        public Task<int> CriarAsync(Usuario usuario);

        public Task AtualizarAsync(Usuario usuario);

        public Task AtualizarSenhaAsync(Usuario usuario, string senhaAntiga);

        public Task<Usuario> ObterAsync (int usuarioId);

        public Task<Usuario> ObterPorEmailAsync (string email);

        public Task DeletarAsync ( int usuarioId);

        public Task RestaurarAsync(int usuarioId);
        public Task<IEnumerable<Usuario>> ListarAsync(bool ativo);

        public IEnumerable<object> ListarTiposUsuario();

    }
}