import { BaseModalStore } from "@/app/BaseStores/BaseModalStore";
import { baseToaster, productCategoryProvider } from "@/app/providers";
import { ProductCategoryUpsertDto } from "@/app/Providers/ProductCategoryProvider";
import { getItemWithExpiry } from "@/app/util/tokenStorage";
import { action, makeObservable, observable } from "mobx";

export class ProductCategoryUpsertStore extends BaseModalStore {
  item: ProductCategoryUpsertDto = {
    name: "",
    marketId: null,
  };
  itemId: string = "";
  constructor() {
    super();
    makeObservable(this, {
      item: observable,

      init: action,
      cleanData: action.bound,
    });
    this.init();
  }

  init = () => {
    this.cleanData();
  };
  async save(): Promise<void> {
    if (this.itemId != "") {
      let response = await productCategoryProvider.update(
        this.itemId,
        this.item
      );

      if (response != null) {
        baseToaster.toastSuccess("Successfully edited product category");
      }
    } else {
      let response = await productCategoryProvider.create(this.item);

      if (response != null) {
        baseToaster.toastSuccess("Successfully added product category");
      }
    }

    this.closeModal();
  }
  cleanData = () => {
    const marketId = getItemWithExpiry<string>("marketId");
    if (this.item) {
      this.item.marketId = marketId;
      this.item.name = "";
    }
  };
}
