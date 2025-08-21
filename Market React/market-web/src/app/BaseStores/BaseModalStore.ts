import { action, makeObservable, observable } from "mobx";

export class BaseModalStore {
  isOpen: boolean = false;
  constructor() {
    makeObservable(this, {
      isOpen: observable,

      openModal: action.bound,
      closeModal: action.bound,
      save: action.bound,
    });
  }

  openModal = () => {
    this.isOpen = true;
  };

  closeModal = () => {
    this.isOpen = false;
    this.onClose();
  };
  onClose(): void {
    throw new Error("onclose method must be implemented in subclass");
  }

  async save(): Promise<void> {
    throw new Error("save method must be implemented in subclass");
  }
}
