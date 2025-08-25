import { BasePaginationStore } from "@/app/BaseStores/BasePaginationStore";
import config from "@/app/config";
import { productProvider } from "@/app/providers";
import {
  ProductDto,
  ProductSearchObject,
} from "@/app/Providers/ProductProvider";
import { getItemWithExpiry } from "@/app/util/tokenStorage";
import { action, makeObservable } from "mobx";

class ProductListStore extends BasePaginationStore<
  ProductDto,
  ProductSearchObject
> {
  constructor() {
    super();
    makeObservable(this, {
      init: action.bound,
      loadData: action.bound,
      edit: action.bound,
      remove: action.bound,
    });
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
      this.items = await productProvider.getPaged(
        this.currentPage,
        this.pageSize,
        this.search
      );
    } catch (err: any) {}
  }
  edit(item: any) {}
  remove(item: any) {}
}

export const productListStore = new ProductListStore();
