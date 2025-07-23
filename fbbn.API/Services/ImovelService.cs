using fbbn.API.DTOs;
using fbbn.API.Models;
using fbbn.API.Repositories;
namespace fbbn.API.Services
{
    public class ImovelService(IImovelRepository imovelRepository) : IImovelService
    {   
        private readonly IImovelRepository _imovelRepository = imovelRepository;
        public async Task<Imovel> CreateImovelAsync(ImovelDTO dto)
        {
            var imovel = new Imovel(
                dto.Nome,
                dto.Descricao,
                dto.Endereco,
                dto.Bairro,
                dto.Cidade,
                dto.Estado,
                dto.CEP,
                dto.DataLancamento,
                dto.Preco,
                dto.Precom2,
                dto.Tipo,
                dto.Metragem,
                dto.Quartos,
                dto.Banheiros,
                dto.VagasGaragem,
                dto.PosicaoSol
            );

            await _imovelRepository.CreateAsync(imovel);
            return imovel;
        }
        public async Task<List<Imovel>> GetAllImoveisAsync()
        {
            var imoveis = await _imovelRepository.GetAllAsync();
            return [.. imoveis];
        }
        public async Task<Imovel> GetImovelByIdAsync(string imovelId)
        {
            var imovel = await _imovelRepository.GetByIdAsync(imovelId) ?? throw new KeyNotFoundException($"Imóvel com ID {imovelId} não encontrado.");
            return imovel;
        }
        public async Task<Imovel> UpdateImovelAsync(string id, ImovelUpdateDTO dto)
        {
            var imovel = await _imovelRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Imóvel com ID {id} não encontrado.");

            imovel.Update(dto);

            await _imovelRepository.UpdateAsync(imovel);
            return imovel;
        }
        public async Task DeleteImovelAsync(string imovelId)
        {
            await _imovelRepository.DeleteAsync(imovelId);
        }
    }
}
