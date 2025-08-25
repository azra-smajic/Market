import { toast } from "react-toastify";

export class BaseToaster {
  toastSuccess = (message: string) => {
    toast.success(message, {
      position: "bottom-right",
      hideProgressBar: false,
      closeOnClick: false,
      pauseOnHover: true,
      draggable: true,
      theme: "light",
    });
  };
  toastError = (message: string) => {
    toast.error(message, {
      position: "bottom-right",
      hideProgressBar: false,
      closeOnClick: false,
      pauseOnHover: true,
      draggable: true,
      theme: "light",
    });
  };

  toastWarning = (message: string) => {
    toast.warning(message, {
      position: "bottom-right",
      hideProgressBar: false,
      closeOnClick: false,
      pauseOnHover: true,
      draggable: true,
      theme: "light",
    });
  };
}
