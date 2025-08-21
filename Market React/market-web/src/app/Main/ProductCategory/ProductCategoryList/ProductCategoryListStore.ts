import {
  ProductCategoryDto,
  ProductCategorySearchObject,
} from "@/app/Providers/ProductCategoryProvider";
import { action, makeObservable } from "mobx";
import { BasePaginationStore } from "../../../BaseStores/BasePaginationStore";
import config from "../../../config";
import { productCategoryProvider } from "../../../providers";
import { getItemWithExpiry } from "../../../util/tokenStorage";
import { ProductCategoryUpsertStore } from "../ProductCategoryUpsert/ProductCategoryUpsertStore";

class ProductCategoryListStore extends BasePaginationStore<
  ProductCategoryDto,
  ProductCategorySearchObject
> {
  productCategoryUpsertStore: any;
  constructor() {
    super();
    makeObservable(this, {
      init: action.bound,
      loadData: action.bound,
      edit: action.bound,
      remove: action.bound,
    });
    this.productCategoryUpsertStore = new ProductCategoryUpsertStore();
    this.init();
  }

  init = async () => {
    this.search = {
      marketId: getItemWithExpiry(config.MARKET_ID),
      searchFilter: "",
    };
    this.productCategoryUpsertStore.onClose = () => {
      this.loadData();
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
  edit(item: any) {
    this.productCategoryUpsertStore.cleanData();
    this.productCategoryUpsertStore.item.name = item.name;
    this.productCategoryUpsertStore.itemId = item.id;
    this.productCategoryUpsertStore.openModal();
  }
  remove(item: any) {}
}

export const productCategoryListStore = new ProductCategoryListStore();
