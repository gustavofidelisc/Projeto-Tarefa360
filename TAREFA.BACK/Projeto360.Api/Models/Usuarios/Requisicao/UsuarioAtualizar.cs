namespace Projeto360.Api.Models.Requisicao
{
    public class UsuarioAtualizar
    {
        public int ID { get; set; }   
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}