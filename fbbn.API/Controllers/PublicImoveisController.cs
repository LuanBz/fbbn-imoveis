using fbbn.API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/imoveis")]
[EnableCors("PublicFrontend")]
public class PublicImoveisController(IImovelService imovelService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllImoveis() =>
        Ok(await imovelService.GetAllImoveisAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImovelById(string id)
    {
        var imovel = await imovelService.GetImovelByIdAsync(id);
        return imovel is null ? NotFound() : Ok(imovel);
    }
    [HttpGet("bairro/{bairro}")]
    public async Task<IActionResult> GetImovelByBairro(string bairro)
    {
        var imovel = await imovelService.GetImovelByBairroAsync(bairro);
        return imovel is null ? NotFound() : Ok(imovel);
    }
}
