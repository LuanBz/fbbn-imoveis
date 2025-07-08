namespace fbbn.API.DTOs 
{ 

    public class ImovelDTO
    {
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required string Endereco { get; set; }
        public required string Bairro { get; set; }
        public string? DataLancamento { get; set; }
        public decimal Preco { get; set; }
        public decimal Precom2 { get; set; }
        public required string Tipo { get; set; }
        public string? Metragem { get; set; }
        public string? Quartos { get; set; }
        public string? Banheiros { get; set; }
        public string? VagasGaragem { get; set; }
    }
}
