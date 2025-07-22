"use client";
import InboxIcon from "@mui/icons-material/MoveToInbox";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";
import Divider from "@mui/material/Divider";
import Drawer from "@mui/material/Drawer";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import Toolbar from "@mui/material/Toolbar";
import Image from "next/image";
import { useState } from "react";
import ProductCategoryListPage from "../Main/ProductCategory/ProductCategoryListPage";
import { useAuthGuard } from "../Providers/AuthProvider";
const drawerWidth = 240;

export default function MainPage() {
  useAuthGuard();
  const [currentPage, setCurrentPage] = useState("dashboard");

  return (
    <Box
      sx={{
        display: "flex",
        minHeight: "100vh",
        backgroundColor: "#f0f0f0", // svijetlosiva
      }}
    >
      <CssBaseline />

      <Drawer
        variant="permanent"
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: {
            width: drawerWidth,
            boxSizing: "border-box",
            backgroundColor: "black",
            color: "silver",
            boxShadow: "9px 1px 13px -7px rgba(0,0,0,0.75)",
          },
        }}
      >
        <Box sx={{ overflow: "auto" }}>
          <Image
            src="/logo-side-bar.png" // relativna putanja iz public foldera
            alt="Opis slike"
            width={200}
            height={150}
            style={{ position: "relative", left: "15px" }}
          />
          <List>
            <ListItem key={"Categories"} disablePadding>
              <ListItemButton onClick={() => setCurrentPage("categories")}>
                <ListItemIcon>
                  <InboxIcon sx={{ color: "silver" }} />
                </ListItemIcon>
                <ListItemText primary={"Categories"} />
              </ListItemButton>
            </ListItem>
          </List>
          <Divider />
        </Box>
      </Drawer>
      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        {currentPage === "categories" ? (
          <ProductCategoryListPage></ProductCategoryListPage>
        ) : (
          "MAIN"
        )}
      </Box>
    </Box>
  );
}
