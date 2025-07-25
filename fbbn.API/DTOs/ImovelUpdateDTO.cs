namespace fbbn.API.DTOs
{

    public class ImovelUpdateDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Status { get; set; }
        public string? Tags { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? Preco { get; set; }
        public decimal? Precom2 { get; set; }
        public string? DataLancamento { get; set; }
        public string? Tipo { get; set; }
        public double? AreaTotal { get; set; }
        public double? AreaConstruida { get; set; }
        public string? Metragem { get; set; }
        public string? Quartos { get; set; }
        public string? Banheiros { get; set; }
        public string? VagasGaragem { get; set; }
        public string? PosicaoSol { get; set; }
        public List<string>? Imagens { get; set; }
    }

}
