using fbbn.API.Models;

namespace fbbn.API.Repositories
{
    public interface IImovelRepository
    {
        Task<Imovel> CreateAsync(Imovel imovel);
        Task<List<Imovel>> GetAllAsync();
        Task<Imovel?> GetByIdAsync(string imovelId);
        Task<List<Imovel>> GetByBairroAsync(string bairro);
        Task<Imovel?> UpdateAsync(Imovel imovel);
        Task<bool> DeleteAsync(string imovelId);
    }
}
