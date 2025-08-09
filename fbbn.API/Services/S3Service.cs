using Amazon.S3;
using Amazon.S3.Transfer;
using fbbn.API.DTOs;

namespace fbbn.API.Services
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _config;
        private readonly IImovelService _imovelService;

        public S3Service(IAmazonS3 s3Client, IConfiguration config, IImovelService imovelService)
        {
            _s3Client = s3Client;
            _config = config;
            _imovelService = imovelService;
        }
        public async Task<List<string>> UploadImagensAsync(string imovelId, List<IFormFile> imgs)
        {
            var bucketName = _config["AWS:BucketName"]!;
            var urls = new List<string>();
            var transferUtility = new TransferUtility(_s3Client);

            var tasks = imgs.Select(img =>
            {
                if (img.Length == 0) return Task.CompletedTask;
                var fileName = $"imoveis/{imovelId}/{Guid.NewGuid()}_{img.FileName}";
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = img.OpenReadStream(),
                    BucketName = bucketName,
                    Key = fileName,
                    ContentType = img.ContentType
                };
                return transferUtility.UploadAsync(uploadRequest).ContinueWith(t =>
                {
                    if (t.IsCompletedSuccessfully)
                    {
                        urls.Add($"https://{bucketName}.s3.amazonaws.com/{fileName}");
                    }
                });
            });
            await Task.WhenAll(tasks);
            return urls;
        }
        public async Task AttachImagesToImovel(string imovelId, List<string> urls)
        {
            var imovel = await _imovelService.GetImovelByIdAsync(imovelId) ?? throw new Exception($"Imóvel com ID {imovelId} não encontrado.");

            imovel.Imagens ??= new List<string>();
            imovel.Imagens.AddRange(urls);

            var imovelDTO = new ImovelUpdateDTO
            {
                Imagens = imovel.Imagens,
                Nome = imovel.Nome,
                Descricao = imovel.Descricao,
                Endereco = imovel.Endereco,
                Rua = imovel.Rua,
                Numero = imovel.Numero,
                Bairro = imovel.Bairro,
                Cidade = imovel.Cidade,
                Estado = imovel.Estado,
                CEP = imovel.CEP,
                Status = imovel.Status,
                Tags = imovel.Tags,
                Caracteristicas = imovel.Caracteristicas,
                Latitude = imovel.Latitude,
                Longitude = imovel.Longitude,
                Preco = imovel.Preco,
                Precom2 = imovel.Precom2,
                DataLancamento = imovel.DataLancamento,
                Tipo = imovel.Tipo,
                AreaTotal = imovel.AreaTotal,
                AreaConstruida = imovel.AreaConstruida,
                Metragem = imovel.Metragem,
                Quartos = imovel.Quartos,
                Suites = imovel.Suites,
                Banheiros = imovel.Banheiros,
                VagasGaragem = imovel.VagasGaragem,
                PosicaoSol = imovel.PosicaoSol
            };

            await _imovelService.UpdateImovelAsync(imovel.imovelId, imovelDTO);
        }

    }
}
