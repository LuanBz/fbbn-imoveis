export type Imovel = {
    imovelId: string;
    nome: string;
    descricao: string;
    endereco: string;
    bairro: string;
    cidade: string;
    estado: string;
    cep: string;
    latitude: number;
    longitude: number;
    status: string;
    tags: string[];
    preco: number;
    precom2: number;
    dataLancamento: Date;
    tipo: string;
    areaTotal: number;
    areaConstruida: number;
    metragem: string;
    quartos: string;
    banheiros: string;
    vagasGaragem: string;
    posicaoSol: string;
    imagens: string[];
}