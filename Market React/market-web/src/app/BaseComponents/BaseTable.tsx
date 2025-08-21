"use client";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import {
  Box,
  Button,
  CircularProgress,
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  Typography,
} from "@mui/material";
import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";

type Column<T> = {
  title: string;
  render: (item: T) => React.ReactNode;
};

type Props<T> = {
  store: {
    items: any[];
    isLoading: boolean;
    currentPage: number;
    pageSize: number;
    computedTotalItems: number;
    loadData: () => Promise<void>;
    setAllPagingParameters: (page: number, totalCount: number) => void;
    setPage: (page: number) => void;
  };
  columns: Column<T>[];
  onEdit?: (item: T) => void;
  onDelete?: (item: T) => void;
  onAdd?: () => void;
  title?: string;
};

export const BaseTable = observer(
  <T,>({ store, columns, onEdit, onDelete, onAdd, title }: Props<T>) => {
    useEffect(() => {
      store.loadData();
    }, [store]);

    if (store.isLoading)
      return (
        <Box display="flex" justifyContent="center" p={3}>
          <CircularProgress />
        </Box>
      );

    return (
      <>
        {/* Header Box iznad tabele */}
        <Box
          sx={{
            backgroundColor: "white",
            padding: 2,
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            borderRadius: 2,
            marginBottom: 2,
            boxShadow: 1,
          }}
        >
          <Typography variant="h6" sx={{ fontWeight: "bold" }}>
            {title}
          </Typography>
          <Button
            variant="contained"
            color="primary"
            onClick={onAdd}
            sx={{ width: "100px" }}
          >
            Add +
          </Button>
        </Box>
        <Paper style={{ backgroundColor: "#fff", padding: 8 }}>
          <Table stickyHeader size="small">
            <TableHead sx={{ borderColor: "black !important" }}>
              <TableRow>
                {columns.map((col, i) => (
                  <TableCell key={i} style={{ color: "gray" }}>
                    {col.title}
                  </TableCell>
                ))}
                <TableCell
                  align="right"
                  sx={{
                    position: "sticky",
                    right: "50px",
                    backgroundColor: "#fff",
                    zIndex: 10,
                    color: "gray",
                  }}
                >
                  Akcije
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {store.items.map((item, rowIdx) => (
                <TableRow key={rowIdx}>
                  {columns.map((col, colIdx) => (
                    <TableCell
                      sx={{
                        fontSize: "small",
                      }}
                      key={colIdx}
                    >
                      {col.render(item)}
                    </TableCell>
                  ))}
                  <TableCell
                    align="right"
                    sx={{
                      position: "sticky",
                      right: 0,
                      backgroundColor: "#fff",
                      zIndex: 10,
                    }}
                  >
                    {onEdit && (
                      <IconButton onClick={() => onEdit(item)}>
                        <EditIcon />
                      </IconButton>
                    )}
                    {onDelete && (
                      <IconButton onClick={() => onDelete(item)}>
                        <DeleteIcon />
                      </IconButton>
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>

          <TablePagination
            component="div"
            count={store.computedTotalItems}
            page={store.currentPage - 1}
            onPageChange={(_, newPage) => store.setPage(newPage + 1)}
            rowsPerPage={store.pageSize}
            rowsPerPageOptions={[store.pageSize]}
          />
        </Paper>
      </>
    );
  }
);
