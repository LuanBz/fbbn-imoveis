using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using fbbn.API.Models;

namespace fbbn.API.Repositories
{
    public class ImovelRepository(DynamoDBContext context) : IImovelRepository
    {
        private readonly DynamoDBContext _context = context;
        public async Task<Imovel> CreateAsync(Imovel imovel)
        {
            await _context.SaveAsync(imovel);
            return imovel;
        }
        public async Task<List<Imovel>> GetAllAsync()
        {
            var search = _context.ScanAsync<Imovel>(new List<ScanCondition>());
            var imoveis = new List<Imovel>();
            do
            {
                var page = await search.GetNextSetAsync();
                imoveis.AddRange(page);
            } while (!search.IsDone);
            return imoveis;
        } 
        public async Task<Imovel?> GetByIdAsync(string imovelId)
        {
            return await _context.LoadAsync<Imovel>(imovelId);
        }
        public async Task<Imovel?> UpdateAsync(Imovel imovel)
        {
            var existingImovel = await _context.LoadAsync<Imovel>(imovel.imovelId);
            if (existingImovel == null)
            {
               throw new KeyNotFoundException($"Imovel with ID {imovel.imovelId} not found.");
            }

            await _context.SaveAsync(imovel);
            return imovel;
        }
        public async Task<bool> DeleteAsync(string imovelId)
        {
            var existingImovel = await _context.LoadAsync<Imovel>(imovelId);
            if (existingImovel == null)
            {
                throw new KeyNotFoundException($"Imovel with ID {imovelId} not found.");
            }
            await _context.DeleteAsync(existingImovel);
            return true;
        }
    }
}
