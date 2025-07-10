using fbbn.API.DTOs;
using fbbn.API.Models;
using fbbn.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace fbbn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController(IImovelService imovelService) : ControllerBase
    {
        private readonly IImovelService _imovelService = imovelService;

        [HttpGet]
        public async Task<IActionResult> GetAllImoveis()
        {
            var imoveis = await _imovelService.GetAllImoveisAsync();
            return Ok(imoveis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImovelById(string id)
        {
            var imovel = await _imovelService.GetImovelByIdAsync(id);
            if (imovel == null) return NotFound();
            return Ok(imovel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateImovel([FromBody] ImovelDTO imovel)
        {
            var createdImovel = await _imovelService.CreateImovelAsync(imovel);
            return CreatedAtAction(nameof(GetImovelById), new { id = createdImovel.imovelId }, createdImovel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImovel(string id, [FromBody] ImovelDTO imovel)
        {
            var updatedImovel = await _imovelService.UpdateImovelAsync(id, imovel);
            return Ok(updatedImovel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var imovel = await _imovelService.GetImovelByIdAsync(id) ?? throw new KeyNotFoundException($"Imóvel com ID {id} não encontrado.");

            await _imovelService.DeleteImovelAsync(id);
            return Ok($"Imóvel com ID {id} deletado com sucesso.");
        }
    }
}
