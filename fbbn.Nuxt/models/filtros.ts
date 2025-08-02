export type Filtros = {
    tipo: string[];
    precoMin: number | null;
    precoMax: number | null;
    precoM2Min: number | null;
    precoM2Max: number | null;
    areaMin: number | null;
    areaMax: number | null;
    quartos: string[];
    banheiros: string[];
    vagas: string[];
    sol: string[];
    filtrosRapidos: {
        ordenacao: null,
        tagsSelecionadas: [],
    }
};
