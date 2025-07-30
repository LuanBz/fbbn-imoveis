export function formatPrice(valor: number): string {
    return valor
        .toFixed(2)
        .replace(".", ",")
        .replace(/\B(?=(\d{3})+(?!\d))/g, ".");
}