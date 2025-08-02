export const localState = () =>
  useState<string[]>("locale", () => []);
