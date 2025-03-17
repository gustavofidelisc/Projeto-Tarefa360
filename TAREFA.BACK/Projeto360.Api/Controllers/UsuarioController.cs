using Microsoft.AspNetCore.Mvc;
using Projeto360.Dominio.Entidades;

using Projeto360.Api.Models.Requisicao;
using Projeto360.Api.Models.Resposta;
using Projeto360.Dominio;

namespace Projeto.Api
{
    [ApiController]
    [Route("[Controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao _usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            _usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        [Route("Obter/{usuarioId}")]
        public async Task<IActionResult> ObterAsync([FromRoute] int usuarioId){
            try
            {
                var usuarioDominio = await _usuarioAplicacao.ObterAsync(usuarioId);

                var usuarioResposta = new UsuarioResposta( ){
                    Id = usuarioDominio.ID,
                    Nome = usuarioDominio.Nome,
                    Email = usuarioDominio.Email,
                    TipoUsuarioId = usuarioDominio.TipoUsuarioId
                };

                return Ok(usuarioResposta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<IActionResult> CriarAsync([FromBody] UsuarioCriar usuarioCriar){
            try
            {
                var usuarioDominio = new Usuario() {
                    Nome = usuarioCriar.Nome,
                    Email = usuarioCriar.Email,
                    Senha = usuarioCriar.Senha,
                    TipoUsuarioId = usuarioCriar.TipoUsuarioId
                };

                var usuarioId = await _usuarioAplicacao.CriarAsync(usuarioDominio);

                return Ok(usuarioId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = $"{ex.Message}" });
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> AtualizarAsync([FromBody] UsuarioAtualizar usuario){
            try
            {
                var usuarioDominio = new Usuario() {
                    ID = usuario.ID,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    TipoUsuarioId = usuario.TipoUsuarioId
                };

                await _usuarioAplicacao.AtualizarAsync(usuarioDominio);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("AtualizarSenha")]
        public async Task<IActionResult> AtualizarSenhaAsync([FromBody] UsuarioAlterarSenha usuario){
            try
            {
                var usuarioDominio = new Usuario() {
                    ID = usuario.ID,
                    Senha = usuario.Senha,
                };

                await _usuarioAplicacao.AtualizarSenhaAsync(usuarioDominio, usuario.SenhaAntiga);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("Deletar/{usuarioID}")]
        public async Task<IActionResult> DeletarAsync([FromRoute] int usuarioID){
            try
            {
                await _usuarioAplicacao.DeletarAsync(usuarioID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Restaurar/{usuarioID}")]
        public async Task <IActionResult> RestaurarAsync([FromRoute] int usuarioID){
            try
            {
                await _usuarioAplicacao.RestaurarAsync(usuarioID);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task <IActionResult> ListarAsync( [FromQuery] bool ativo){
            try
            {
                var usuarios = await _usuarioAplicacao.ListarAsync(ativo);

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarTiposUsuario")]
        public IActionResult ListarTipoUsuario(){
            try
            {
                var listaTipoUsuarios = _usuarioAplicacao.ListarTiposUsuario();

                return Ok(listaTipoUsuarios);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
        




    }

}