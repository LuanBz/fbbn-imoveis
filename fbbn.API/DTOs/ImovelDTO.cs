namespace fbbn.API.DTOs 
{ 

    public class ImovelDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? DataLancamento { get; set; }
        public decimal Preco { get; set; }
        public decimal Precom2 { get; set; }
        public string? Tipo { get; set; }
        public string? Metragem { get; set; }
        public string? Quartos { get; set; }
        public string? Banheiros { get; set; }
        public string? VagasGaragem { get; set; }
    }
}
