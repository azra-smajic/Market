import { BaseModalStore } from "@/app/BaseStores/BaseModalStore";
import { productCategoryProvider } from "@/app/providers";
import { ProductCategoryUpsertDto } from "@/app/Providers/ProductCategoryProvider";
import { getItemWithExpiry } from "@/app/util/tokenStorage";
import { action, makeObservable, observable } from "mobx";
import { toast } from "react-toastify";

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
        toast.success("Successfully edited product category", {
          position: "bottom-right",
          hideProgressBar: false,
          closeOnClick: false,
          pauseOnHover: true,
          draggable: true,
          theme: "light",
        });
      }
    } else {
      let response = await productCategoryProvider.create(this.item);

      if (response != null) {
        toast.success("Successfully created/edited product category", {
          position: "bottom-right",
          hideProgressBar: false,
          closeOnClick: false,
          pauseOnHover: true,
          draggable: true,
          theme: "light",
        });
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
