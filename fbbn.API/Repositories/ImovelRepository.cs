﻿using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
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
        public async Task<List<Imovel>> GetByBairroAsync(string bairro)
        {
           var conditions = new List<ScanCondition>
            {
                new ScanCondition("Bairro", ScanOperator.Equal, bairro)
            };

            var search = await _context.ScanAsync<Imovel>(conditions).GetNextSetAsync();

            if (!search.Any())
            {
                throw new Exception($"Não foi encontrado imóveis em {bairro}.");
            }

            return search.ToList();
        }
        public async Task<Imovel?> GetByTagAsync(string tags)
        {
            var conditions = new List<ScanCondition>
            {
                new ScanCondition("Tags", ScanOperator.Contains, tags)
            };

            var search = await _context.ScanAsync<Imovel>(conditions).GetNextSetAsync();

            if (!search.Any())
            {
                throw new Exception($"Não foi encontrado imóveis com a tag {tags}.");
            }
            return search.FirstOrDefault();
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
            var existingImovel = await _context.LoadAsync<Imovel>(imovelId) ?? throw new KeyNotFoundException($"Imovel with ID {imovelId} not found.");

            await _context.DeleteAsync(existingImovel);
            return true;
        }
    }
}
