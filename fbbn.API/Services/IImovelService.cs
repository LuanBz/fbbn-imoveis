using fbbn.API.DTOs;
using fbbn.API.Models;

namespace fbbn.API.Services
{
    public interface IImovelService
    {
        Task<Imovel> CreateImovelAsync(ImovelDTO dto);
        Task<List<Imovel>> GetAllImoveisAsync();
        Task<Imovel> GetImovelByIdAsync(string imovelId);
        Task<Imovel> UpdateImovelAsync(string id, ImovelDTO dto);
        Task DeleteImovelAsync(string imovelId);
    }
}
