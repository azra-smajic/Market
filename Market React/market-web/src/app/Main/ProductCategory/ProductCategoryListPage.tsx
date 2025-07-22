import { BaseTable } from "../../Components/BaseTable";
import { productCategoryStore } from "./ProductCategoryStore";

const columns = [{ title: "Name", render: (item: any) => item.name }];

export default function ProductCategoryPage() {
  return <BaseTable store={productCategoryStore} columns={columns} />;
}
