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
            var imovel = new Imovel
             {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Endereco = dto.Endereco,
                Rua = dto.Rua,
                Numero = dto.Numero,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                CEP = dto.CEP,
                DataLancamento = dto.DataLancamento,
                Preco = dto.Preco,
                Precom2 = dto.Precom2,
                Tipo = dto.Tipo ?? string.Empty,
                Caracteristicas = dto.Caracteristicas,
                Metragem = dto.Metragem,
                Quartos = dto.Quartos,
                Suites = dto.Suites,
                Banheiros = dto.Banheiros,
                VagasGaragem = dto.VagasGaragem,
                PosicaoSol = dto.PosicaoSol,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                AreaTotal = dto.AreaTotal,
                AreaConstruida = dto.AreaConstruida,
                Status = dto.Status,
                Tags = dto.Tags
            };

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
        public async Task<List<Imovel>> GetImovelByBairroAsync(string bairro)
        {
            var imovel = await _imovelRepository.GetByBairroAsync(bairro) ?? throw new KeyNotFoundException($"Imóvel no bairro {bairro} não encontrado.");
            return imovel;
        }
        public async Task<Imovel> GetImovelByTagAsync(string tag)
        {
            var imovel = await _imovelRepository.GetByTagAsync(tag) ?? throw new KeyNotFoundException($"Imóvel com a tag {tag} não encontrado.");
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
