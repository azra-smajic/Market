"use client";
import { observer } from "mobx-react-lite";
import { useRouter } from "next/navigation";
import { BaseTable } from "../../../BaseComponents/BaseTable";
import { productListStore } from "./ProductListStore";
const columns = [
  { title: "Name", render: (item: any) => item.name },
  { title: "SKU", render: (item: any) => item.sku },
  {
    title: "Product Category",
    render: (item: any) => item.productCategoryName,
  },
  { title: "Price", render: (item: any) => item.price },
  { title: "Currency", render: (item: any) => item.currency },
  { title: "Discount", render: (item: any) => item.discount },
  { title: "Tax Rate", render: (item: any) => item.taxRate },
  { title: "Status", render: (item: any) => item.status },
];
const ProductListPage = observer(() => {
  const router = useRouter();
  return (
    <>
      <BaseTable
        store={productListStore}
        columns={columns}
        onEdit={productListStore.edit}
        onDelete={productListStore.remove}
        onAdd={() => {
          router.push("./ProductUpsert");
        }}
        title="Products"
      />
    </>
  );
});
export default ProductListPage;
