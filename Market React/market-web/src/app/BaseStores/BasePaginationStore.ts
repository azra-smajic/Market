import { action, computed, makeObservable, observable } from "mobx";
import { BaseIndexDto, BaseSearchObject } from "../Providers/BaseProvider";
import config from "../config";

export class BasePaginationStore<
  T extends BaseIndexDto = BaseIndexDto,
  TSearch extends BaseSearchObject = BaseSearchObject,
> {
  items: T[] = [];
  isLoading: boolean = false;
  currentPage: number = 1;
  pageSize: number = config.PAGE_SIZE;
  totalItems: number = 0;
  search?: TSearch;

  constructor() {
    makeObservable(this, {
      items: observable,
      isLoading: observable,
      currentPage: observable,
      pageSize: observable,
      totalItems: observable,

      setAllPagingParameters: action,
      setPage: action,
      setTotalItems: action,
      setLoading: action,
      setSearchQuery: action,
      computedTotalItems: computed,
    });
  }
  setAllPagingParameters = (page: number, totalItems: number) => {
    this.setPage(page);
    this.setTotalItems(totalItems);
  };
  get computedTotalItems(): number {
    return this.items[0]?.totalRecordsCount ?? this.totalItems;
  }
  setPage = (page: number) => {
    this.currentPage = page;
    this.loadData();
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
