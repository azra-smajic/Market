import {
  ProductCategoryDto,
  ProductCategorySearchObject,
} from "@/app/Providers/ProductCategoryProvider";
import { makeObservable } from "mobx";
import { BasePaginationStore } from "../../BasePaginationStore";
import config from "../../config";
import { productCategoryProvider } from "../../providers";
import { getItemWithExpiry } from "../../util/tokenStorage";

class ProductCategoryStore extends BasePaginationStore<
  ProductCategoryDto,
  ProductCategorySearchObject
> {
  constructor() {
    super();
    makeObservable(this);
    this.init();
  }

  init = async () => {
    this.search = {
      marketId: getItemWithExpiry(config.MARKET_ID),
      searchFilter: "",
    };
  };

  async loadData(): Promise<void> {
    try {
      this.items = await productCategoryProvider.getPaged(
        this.currentPage,
        this.pageSize,
        this.search
      );
    } catch (err: any) {}
  }
  edit(item: any) {}
  remove(item: any) {}
}

export const productCategoryStore = new ProductCategoryStore();
