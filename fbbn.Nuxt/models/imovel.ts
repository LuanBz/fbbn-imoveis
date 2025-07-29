export type Imovel = {
    id: string;
    Nome: string;
    Descricao: string;
    Endereco: string;
    Bairro: string;
    Cidade: string;
    Estado: string;
    CEP: string;
    Latitude: number;
    Longitude: number;
    Status: string;
    Tags: string;
    Preco: number;
    Precom2: number;
    DataLancamento: Date;
    Tipo: string;
    AreaTotal: number;
    AreaConstruida: number;
    Metragem: string;
    Quartos: string;
    Banheiros: string;
    VagasGaragem: string;
    PosicaoSol: string;
    Imagens: string[];
}