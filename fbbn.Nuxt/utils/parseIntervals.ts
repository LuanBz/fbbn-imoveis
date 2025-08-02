export function parseMeters(metragem: string): [number, number] {
    const numeros = metragem
        .match(/\d+/g)
        ?.map((n) => parseInt(n, 10))
        .filter((n) => !isNaN(n)) || [];

    if (numeros.length === 0) return [0, 0];
    if (numeros.length === 1) return [numeros[0], numeros[0]];

    const min = Math.min(...numeros);
    const max = Math.max(...numeros);
    return [min, max];
}

export function parseInterval(valor: string, faixa: string): boolean {
    const valorNumerico = parseInt(valor.trim());

    if (faixa.includes("a")) {
        const [min, max] = faixa.split("a").map((n) => parseInt(n.trim()));
        return valorNumerico >= min && valorNumerico <= max;
    }

    const unico = parseInt(faixa.trim());
    return valorNumerico === unico;
}
