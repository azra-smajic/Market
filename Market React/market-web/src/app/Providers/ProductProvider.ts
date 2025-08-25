import config from "../config";
import { BaseProvider, BaseSearchObject } from "./BaseProvider";

export interface ProductDto {
  name: string;
  sku: string;
  marketId: string;
  productCategoryId: string;
  productCategoryName: string;
  price: number;
  currency: string;
  discount?: number;
  taxRate?: number;
  status: string;
}

export interface ProductSearchObject extends BaseSearchObject {
  marketId?: string | null;
  productCategoryId?: string | null;
}

export class ProductProvider extends BaseProvider<
  ProductDto,
  ProductDto,
  ProductDto,
  ProductSearchObject
> {
  constructor() {
    super(`${config.API_BASE_URL}/Product`);
  }
}
