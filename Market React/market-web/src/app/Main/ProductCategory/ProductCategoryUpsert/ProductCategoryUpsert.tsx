"use client";
import { Box, Button, Modal, TextField, Typography } from "@mui/material";
import { observer } from "mobx-react-lite";

const style = {
  position: "absolute" as const,
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  boxShadow: 24,
  p: 4,
  borderRadius: 2,
};

type Props = {
  store: {
    isOpen: boolean;
    closeModal: () => void;
    save: () => void;
    item?: any;
  };
};

const ProductCategoryUpsertModal = observer(({ store }: Props) => {
  return (
    <Modal open={store.isOpen} onClose={store.closeModal}>
      <Box sx={style}>
        <Typography variant="h6" mb={2}>
          Add Category
        </Typography>
        <TextField
          fullWidth
          label="Name"
          margin="normal"
          value={store.item.name}
          onChange={(e) => {
            store.item.name = e.target.value;
          }}
        />
        <Box display="flex" justifyContent="flex-end" mt={3}>
          <Button onClick={store.closeModal} sx={{ mr: 2 }}>
            Cancel
          </Button>
          <Button variant="contained" onClick={store.save}>
            Save
          </Button>
        </Box>
      </Box>
    </Modal>
  );
});

export default ProductCategoryUpsertModal;
