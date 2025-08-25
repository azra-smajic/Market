import { BaseToaster } from "./BaseStores/BaseToaster";
import { ProductCategoryProvider } from "./Providers/ProductCategoryProvider";
import { ProductProvider } from "./Providers/ProductProvider";

export const productCategoryProvider = new ProductCategoryProvider();
export const productProvider = new ProductProvider();
export const baseToaster = new BaseToaster();
