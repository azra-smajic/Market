import config from "../config";
import { BaseIndexDto, BaseProvider, BaseSearchObject } from "./BaseProvider";

export interface ProductCategoryDto extends BaseIndexDto {
  name: string;
  marketId?: string;
}
export interface ProductCategoryUpsertDto {
  name: string;
  marketId: string | null;
}

export interface ProductCategorySearchObject extends BaseSearchObject {
  marketId?: string | null;
}

export class ProductCategoryProvider extends BaseProvider<
  ProductCategoryDto,
  ProductCategoryUpsertDto,
  ProductCategoryUpsertDto,
  ProductCategorySearchObject
> {
  constructor() {
    super(`${config.API_BASE_URL}/ProductCategory`);
  }
}
