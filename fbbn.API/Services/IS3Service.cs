namespace fbbn.API.Services
{
    public interface IS3Service
    {
        Task<List<string>> UploadImagensAsync(string imovelId, List<IFormFile> imgs);
        Task AttachImagesToImovel(string imovelId, List<string> urls);
    }
}
