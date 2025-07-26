// useLocale.ts (pode criar dentro de ~/composables)
export const localState = () =>
  useState<string[]>("locale", () => ["Rio de Janeiro"]);
