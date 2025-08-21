type StoredItem<T> = {
  value: T;
  expiry: number;
};

// @param ttl Time-To-Live u milisekundama (npr. 2 sata = 2 * 60 * 60 * 1000)
export function setItemWithExpiry<T>(key: string, value: T, ttl: number): void {
  const now = new Date();

  const item: StoredItem<T> = {
    value,
    expiry: now.getTime() + ttl,
  };

  localStorage.setItem(key, JSON.stringify(item));
}

export function getItemWithExpiry<T>(key: string): T | null {
  if (typeof window === "undefined") return null;
  const itemStr = localStorage.getItem(key);

  if (!itemStr) return null;

  try {
    const item: StoredItem<T> = JSON.parse(itemStr);
    const now = new Date();

    if (now.getTime() > item.expiry) {
      localStorage.removeItem(key);
      return null;
    }

    return item.value;
  } catch (error) {
    console.warn("Greška pri parsiranju localStorage vrijednosti:", error);
    localStorage.removeItem(key);
    return null;
  }
}
