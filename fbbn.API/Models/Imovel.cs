using Amazon.DynamoDBv2.DataModel;

namespace fbbn.API.Models
{
    [DynamoDBTable("FBBN-Imobiliaria")]
    public class Imovel
    {
        [DynamoDBHashKey]
        public string imovelId { get; set; }
        [DynamoDBProperty]
        public string Nome { get; set; }
        [DynamoDBProperty]
        public string Descricao { get; set; }
        [DynamoDBProperty]
        public string Endereco { get; set; }
        [DynamoDBProperty]
        public string Bairro { get; set; }
        [DynamoDBProperty]
        public string? DataLancamento { get; set; }
        [DynamoDBProperty]
        public decimal Preco { get; set; }
        [DynamoDBProperty] 
        public decimal Precom2 { get; set; }
        [DynamoDBProperty]
        public string Tipo { get; set; }
        [DynamoDBProperty]
        public string? Metragem { get; set; }
        [DynamoDBProperty]
        public string? Quartos { get; set; }
        [DynamoDBProperty]
        public string? Banheiros { get; set; }
        [DynamoDBProperty]
        public string? VagasGaragem { get; set; }
        [DynamoDBProperty]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public Imovel()
        {
            imovelId = Guid.NewGuid().ToString();
            Nome = string.Empty;
            Descricao = string.Empty;
            Endereco = string.Empty;
            Bairro = string.Empty;
            Tipo = string.Empty;
        }
        public Imovel(string Nome, string Descricao, string Endereco, string Bairro, string? DataLancamento, decimal Preco, decimal Precom2, string? Tipo, string? Metragem, string? Quartos, string? Banheiros, string? VagasGaragem)
        {
            imovelId = Guid.NewGuid().ToString();
            this.Nome = Nome ?? throw new ArgumentNullException(nameof(Nome));
            this.Descricao = Descricao ?? throw new ArgumentNullException(nameof(Descricao));
            this.Endereco = Endereco ?? throw new ArgumentNullException(nameof(Endereco));
            this.Bairro = Bairro ?? throw new ArgumentNullException(nameof(Bairro));
            this.DataLancamento = DataLancamento;
            this.Preco = Preco;
            this.Precom2 = Precom2;
            this.Tipo = Tipo ?? throw new ArgumentNullException(nameof(Tipo));
            this.Metragem = Metragem;
            this.Quartos = Quartos;
            this.Banheiros = Banheiros;
            this.VagasGaragem = VagasGaragem;
            DataCadastro = DateTime.UtcNow;
        }

        public void Update(string? nome, string? descricao, string? endereco, string? bairro, string? dataLancamento, decimal? preco, decimal? precom2, string? tipo, string? metragem, string? quartos, string? banheiros, string? vagasGaragem)
        {
            if (!string.IsNullOrWhiteSpace(nome)) { Nome = nome; }
            if (!string.IsNullOrWhiteSpace(descricao)) { Descricao = descricao; }
            if (!string.IsNullOrWhiteSpace(endereco)) { Endereco = endereco; }
            if (!string.IsNullOrWhiteSpace(bairro)) { Bairro = bairro; }
            if (!string.IsNullOrWhiteSpace(dataLancamento)) { DataLancamento = dataLancamento; }
            if (preco.HasValue) { Preco = preco.Value; }
            if (precom2.HasValue) { Precom2 = precom2.Value; }
            if (!string.IsNullOrWhiteSpace(tipo)) { Tipo = tipo; }
            if (!string.IsNullOrWhiteSpace(metragem)) { Metragem = metragem; }
            if (!string.IsNullOrWhiteSpace(quartos)) { Quartos = quartos; }
            if (!string.IsNullOrWhiteSpace(banheiros)) { Banheiros = banheiros; }
            if (!string.IsNullOrWhiteSpace(vagasGaragem)) { VagasGaragem = vagasGaragem; }
        }

    }

}
