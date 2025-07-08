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
            if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Descricao) || string.IsNullOrWhiteSpace(dto.Endereco) || string.IsNullOrWhiteSpace(dto.Bairro))
            {
                throw new ArgumentException("Nome, Descricao, Endereco e Bairro não pode estar vazio.");
            }

            var imovel = new Imovel(
                dto.Nome,
                dto.Descricao,
                dto.Endereco,
                dto.Bairro,
                dto.DataLancamento,
                dto.Preco,
                dto.Precom2,
                dto.Tipo,
                dto.Metragem,
                dto.Quartos,
                dto.Banheiros,
                dto.VagasGaragem
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
        public async Task<Imovel> UpdateImovelAsync(string id, ImovelDTO dto)
        {
            var imovel = await _imovelRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Imóvel com ID {id} não encontrado.");

            imovel.Update(
                dto.Nome,
                dto.Descricao,
                dto.Endereco,
                dto.Bairro,
                dto.DataLancamento,
                dto.Preco,
                dto.Precom2,
                dto.Tipo,
                dto.Metragem,
                dto.Quartos,
                dto.Banheiros,
                dto.VagasGaragem
            );

            await _imovelRepository.UpdateAsync(imovel);
            return imovel;
        }
        public async Task DeleteImovelAsync(string imovelId)
        {
            await _imovelRepository.DeleteAsync(imovelId);
        }
    }
}
