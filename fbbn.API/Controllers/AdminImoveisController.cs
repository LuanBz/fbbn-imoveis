using fbbn.API.DTOs;
using fbbn.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/admin/imoveis")]
[EnableCors("AdminFrontend")]
// [Authorize] // Se for proteger com JWT depois
public class AdminImoveisController(IImovelService imovelService, IS3Service s3Service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateImovel([FromBody] ImovelDTO imovel)
    {
        var created = await imovelService.CreateImovelAsync(imovel);
        return CreatedAtAction(nameof(CreateImovel), new { id = created.imovelId }, created);
    }

    [HttpPost("{id}/imagens")]
    public async Task<IActionResult> UploadImagens(string id, List<IFormFile> imgs)
    {
        var urls = await s3Service.UploadImagensAsync(id, imgs);
        await s3Service.AttachImagesToImovel(id, urls);
        return Ok(urls);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateImovel(string id, [FromBody] ImovelUpdateDTO imovel)
    {
        var updated = await imovelService.UpdateImovelAsync(id, imovel);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        _ = await imovelService.GetImovelByIdAsync(id) ?? throw new KeyNotFoundException($"Imóvel com ID {id} não encontrado.");

        await imovelService.DeleteImovelAsync(id);
        return Ok($"Imóvel com ID {id} deletado com sucesso.");
    }
}
