using Amazon.DynamoDBv2.DataModel;
using fbbn.API.DTOs;

namespace fbbn.API.Models
{
    [DynamoDBTable("FBBN-Imobiliaria")]
    public class Imovel
    {
        [DynamoDBHashKey]
        public string imovelId { get; set; }
        [DynamoDBProperty] public string Nome { get; set; }
        [DynamoDBProperty] public string Descricao { get; set; }
        [DynamoDBProperty] public string Endereco { get; set; }
        [DynamoDBProperty] public string Bairro { get; set; }
        [DynamoDBProperty] public string Cidade { get; set; }
        [DynamoDBProperty] public string Estado { get; set; }
        [DynamoDBProperty] public string CEP { get; set; }
        [DynamoDBProperty] public double? Latitude { get; set; }
        [DynamoDBProperty] public double? Longitude { get; set; }
        [DynamoDBProperty] public string? DataLancamento { get; set; }

        [DynamoDBProperty] public decimal Preco { get; set; }
        [DynamoDBProperty] public decimal Precom2 { get; set; }

        [DynamoDBProperty] public string Tipo { get; set; }

        [DynamoDBProperty] public double AreaTotal { get; set; }
        [DynamoDBProperty] public double AreaConstruida { get; set; }
        [DynamoDBProperty] public string? Metragem { get; set; }

        [DynamoDBProperty] public string? Quartos { get; set; }
        [DynamoDBProperty] public string? Banheiros { get; set; }
        [DynamoDBProperty] public string? VagasGaragem { get; set; }
        [DynamoDBProperty] public string? PosicaoSol { get; set; }

        [DynamoDBProperty] public List<string>? Imagens { get; set; } = new List<string>();

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public Imovel()
        {
            imovelId = Guid.NewGuid().ToString();
            Nome = string.Empty;
            Descricao = string.Empty;
            Endereco = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Estado = string.Empty;
            CEP = string.Empty;
            Tipo = string.Empty;
        }
        public Imovel(string Nome, string Descricao, string Endereco, string Bairro, string Cidade, string Estado, string CEP, string? DataLancamento, decimal Preco, decimal Precom2, string? Tipo, string? Metragem, string? Quartos, string? Banheiros, string? VagasGaragem, string? posicaoSol)
        {
            imovelId = Guid.NewGuid().ToString();
            this.Nome = Nome ?? throw new ArgumentNullException(nameof(Nome));
            this.Descricao = Descricao ?? throw new ArgumentNullException(nameof(Descricao));
            this.Endereco = Endereco ?? throw new ArgumentNullException(nameof(Endereco));
            this.Bairro = Bairro ?? throw new ArgumentNullException(nameof(Bairro));
            this.Cidade = Cidade ?? throw new ArgumentNullException(nameof(Cidade));
            this.Estado = Estado ?? throw new ArgumentNullException(nameof(Estado));
            this.CEP = CEP ?? throw new ArgumentNullException(nameof(CEP));
            this.DataLancamento = DataLancamento;
            this.Preco = Preco;
            this.Precom2 = Precom2;
            this.Tipo = Tipo ?? throw new ArgumentNullException(nameof(Tipo));
            this.Metragem = Metragem;
            this.Quartos = Quartos;
            this.Banheiros = Banheiros;
            this.VagasGaragem = VagasGaragem;
            DataCadastro = DateTime.UtcNow;
            PosicaoSol = posicaoSol;
        }

        public void Update(ImovelUpdateDTO dto)
        {
            Nome = dto.Nome ?? Nome;
            Descricao = dto.Descricao ?? Descricao;
            Endereco = dto.Endereco ?? Endereco;
            Bairro = dto.Bairro ?? Bairro;
            Cidade = dto.Cidade ?? Cidade;
            Estado = dto.Estado ?? Estado;
            CEP = dto.CEP ?? CEP;
            DataLancamento = dto.DataLancamento ?? DataLancamento;
            Preco = dto.Preco ?? Preco;
            Precom2 = dto.Precom2 ?? Precom2;
            Tipo = dto.Tipo ?? Tipo;
            Metragem = dto.Metragem ?? Metragem;
            Quartos = dto.Quartos ?? Quartos;
            Banheiros = dto.Banheiros ?? Banheiros;
            VagasGaragem = dto.VagasGaragem ?? VagasGaragem;
            PosicaoSol = dto.PosicaoSol ?? PosicaoSol;
            Latitude = dto.Latitude ?? Latitude;
            Longitude = dto.Longitude ?? Longitude;

            if (dto.Imagens != null && dto.Imagens.Any())
                Imagens = dto.Imagens;
        }


    }
}
