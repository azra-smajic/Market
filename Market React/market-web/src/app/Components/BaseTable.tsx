import {
  Box,
  CircularProgress,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
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
    totalItems: number;
    loadData: () => Promise<void>;
    setAllPagingParameters: (page: number, totalCount: number) => void;
    setPage: (page: number) => void;
  };
  columns: Column<T>[];
};

export const BaseTable = observer(<T,>({ store, columns }: Props<T>) => {
  useEffect(() => {
    store.loadData().then(() => {
      const totalCount = store.items[0]?.totalRecordsCount ?? 0;
      store.setAllPagingParameters(1, totalCount);
    });
  }, [store]);

  if (store.isLoading)
    return (
      <Box display="flex" justifyContent="center" p={3}>
        <CircularProgress />
      </Box>
    );

  return (
    <Paper style={{ backgroundColor: "#fff", padding: 8 }}>
      <Table>
        <TableHead>
          <TableRow>
            {columns.map((col, i) => (
              <TableCell key={i}>{col.title}</TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {store.items.map((item, rowIdx) => (
            <TableRow key={rowIdx}>
              {columns.map((col, colIdx) => (
                <TableCell key={colIdx}>{col.render(item)}</TableCell>
              ))}
            </TableRow>
          ))}
        </TableBody>
      </Table>

      <TablePagination
        component="div"
        count={store.totalItems}
        page={store.currentPage - 1}
        onPageChange={(_, newPage) => store.setPage(newPage + 1)}
        rowsPerPage={store.pageSize}
        rowsPerPageOptions={[store.pageSize]}
      />
    </Paper>
  );
});
