import config from "../config";
import { BaseProvider, BaseSearchObject } from "./BaseProvider";

export interface ProductCategoryDto {
  id: number;
  name: string;
  marketId?: string;
  totalRecordsCount?: number;
}

export interface ProductCategorySearchObject extends BaseSearchObject {
  marketId?: string | null;
}

export class ProductCategoryProvider extends BaseProvider<
  ProductCategoryDto,
  ProductCategorySearchObject
> {
  constructor() {
    super(`${config.API_BASE_URL}/ProductCategory`);
  }
}
