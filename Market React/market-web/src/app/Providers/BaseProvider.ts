import config from "../config";
import { getItemWithExpiry } from "../util/tokenStorage";

export interface BaseSearchObject {
  [searchFilter: string]: any;
}
export interface BaseIndexDto {
  [id: string]: any;
  [totalRecordsCount: number]: any;
}

export class BaseProvider<
  TIndex,
  TInsert,
  TUpdate,
  TSearch extends BaseSearchObject = BaseSearchObject,
> {
  protected baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  private getHeaders(): HeadersInit {
    const token = getItemWithExpiry(config.AUTH_TOKEN_KEY);
    return {
      "Content-Type": "application/json",
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
    };
  }

  async getById(id: string | number): Promise<TIndex> {
    const res = await fetch(`${this.baseUrl}/${id}`, {
      headers: this.getHeaders(),
    });
    if (!res.ok) throw new Error("Failed to fetch by ID");
    return res.json();
  }

  async getAll(): Promise<TIndex[]> {
    const res = await fetch(this.baseUrl, {
      headers: this.getHeaders(),
    });
    if (!res.ok) throw new Error("Failed to fetch all");
    return res.json();
  }

  async create(data: TInsert): Promise<TIndex> {
    const res = await fetch(`${this.baseUrl}/Post`, {
      method: "POST",
      headers: this.getHeaders(),
      body: JSON.stringify(data),
    });
    if (!res.ok) throw new Error("Failed to create");
    return res.json();
  }

  async update(id: string | number, data: TUpdate): Promise<TIndex> {
    const res = await fetch(`${this.baseUrl}/Put/${id}`, {
      method: "PUT",
      headers: this.getHeaders(),
      body: JSON.stringify(data),
    });
    if (!res.ok) throw new Error("Failed to update");
    return res.json();
  }

  async delete(id: string | number): Promise<void> {
    const res = await fetch(`${this.baseUrl}/${id}`, {
      method: "DELETE",
      headers: this.getHeaders(),
    });
    if (!res.ok) throw new Error("Failed to delete");
  }

  async getPaged(
    page: number,
    pageSize: number,
    searchParams?: TSearch
  ): Promise<TIndex[]> {
    const url = new URL(
      `${this.baseUrl}/Get/${page}/${pageSize}`,
      window.location.origin
    );

    if (searchParams) {
      Object.entries(searchParams).forEach(([key, value]) => {
        if (value !== undefined && value !== null) {
          const capitalizedKey = key.charAt(0).toUpperCase() + key.slice(1);
          url.searchParams.append(capitalizedKey, value.toString());
        }
      });
    }

    const res = await fetch(url.toString(), {
      headers: this.getHeaders(),
    });
    if (!res.ok) throw new Error("Failed to fetch paged data");
    return res.json();
  }
}
