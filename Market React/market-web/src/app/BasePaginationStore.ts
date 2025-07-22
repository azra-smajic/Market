import { makeObservable } from "mobx";
import { BaseSearchObject } from "./Providers/BaseProvider";
import config from "./config";

export class BasePaginationStore<
  T,
  TSearch extends BaseSearchObject = BaseSearchObject,
> {
  items: T[] = [];
  isLoading: boolean = false;
  currentPage: number = 1;
  pageSize: number = config.PAGE_SIZE;
  totalItems: number = 0;
  search?: TSearch;

  constructor() {
    makeObservable(this);
  }
  setAllPagingParameters = (page: number, totalItems: number) => {
    this.setPage(page);
    this.setTotalItems(totalItems);
  };
  setPage = (page: number) => {
    this.currentPage = page;
  };

  setTotalItems = (total: number) => {
    this.totalItems = total;
  };

  setLoading = (loading: boolean) => {
    this.isLoading = loading;
  };

  setSearchQuery = (query: TSearch) => {
    this.search = query;
  };
  async loadData(): Promise<void> {
    throw new Error("loadData method must be implemented in subclass");
  }

  get totalPage() {
    return Math.ceil(this.totalItems / this.pageSize);
  }
}
