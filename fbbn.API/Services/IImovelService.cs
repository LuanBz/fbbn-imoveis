using fbbn.API.DTOs;
using fbbn.API.Models;

namespace fbbn.API.Services
{
    public interface IImovelService
    {
        Task<Imovel> CreateImovelAsync(ImovelDTO dto);
        Task<List<Imovel>> GetAllImoveisAsync();
        Task<Imovel> GetImovelByIdAsync(string imovelId);
        Task<List<Imovel>> GetImovelByBairroAsync(string bairro);
        Task<Imovel> GetImovelByTagAsync(string tags);
        Task<Imovel> UpdateImovelAsync(string id, ImovelUpdateDTO dto);
        Task DeleteImovelAsync(string imovelId);
    }
}
