"use client";
import { observer } from "mobx-react-lite";
import { BaseTable } from "../../../BaseComponents/BaseTable";
import ProductCategoryAddModal from "../ProductCategoryUpsert/ProductCategoryUpsert";
import { productCategoryListStore } from "./ProductCategoryListStore";

const columns = [{ title: "Name", render: (item: any) => item.name }];

const ProductCategoryListPage = observer(() => {
  return (
    <>
      <BaseTable
        store={productCategoryListStore}
        columns={columns}
        onEdit={productCategoryListStore.edit}
        onDelete={productCategoryListStore.remove}
        onAdd={() => {
          productCategoryListStore.productCategoryUpsertStore.cleanData();
          productCategoryListStore.productCategoryUpsertStore.openModal();
        }}
        title="Product Categories"
      />
      <ProductCategoryAddModal
        store={productCategoryListStore.productCategoryUpsertStore}
      />
    </>
  );
});
export default ProductCategoryListPage;
