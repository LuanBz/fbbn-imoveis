using fbbn.API.DTOs;
using fbbn.API.Models;
using fbbn.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace fbbn.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController(IImovelService imovelService, IS3Service s3Service) : ControllerBase
    {
        private readonly IImovelService _imovelService = imovelService;
        private readonly IS3Service _s3Service = s3Service;

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

        [HttpPost("{id}/imagens")]
        public async Task<IActionResult> UploadImagens(string id, List<IFormFile> imgs)
        {
            var urls = await _s3Service.UploadImagensAsync(id, imgs);
            await _s3Service.AttachImagesToImovel(id, urls);
            return Ok(urls);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateImovel(string id, [FromBody] ImovelUpdateDTO imovel)
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
