import { GetAllItems } from '~/api/GetAPI';
import type { Imovel } from '~/models/imovel';

export const useNovidade = () =>
    useAsyncData<Imovel | null>('novidade', async () => {
        const all = await GetAllItems();
        return all.find((item) => item.tags?.includes('Novidade')) || null;
    });
