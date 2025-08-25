"use client";
import InboxIcon from "@mui/icons-material/MoveToInbox";
import {
  Box,
  CssBaseline,
  Divider,
  Drawer,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Toolbar,
} from "@mui/material";
import Image from "next/image";
import Link from "next/link";
import { usePathname } from "next/navigation";
import { ToastContainer } from "react-toastify";

const drawerWidth = 240;

export default function MainLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const pathname = usePathname();

  return (
    <Box
      sx={{ display: "flex", minHeight: "100vh", backgroundColor: "#f0f0f0" }}
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
          },
        }}
      >
        <Box sx={{ overflow: "auto" }}>
          <Image
            src="/logo-side-bar.png"
            alt="Logo"
            width={200}
            height={150}
            style={{ position: "relative", left: "15px" }}
          />
          <List>
            <ListItem disablePadding>
              <ListItemButton
                component={Link}
                href="/Main/ProductCategory/ProductCategoryList"
                selected={pathname.includes(
                  "/ProductCategory/ProductCategoryList"
                )}
              >
                <ListItemIcon>
                  <InboxIcon sx={{ color: "silver" }} />
                </ListItemIcon>
                <ListItemText primary="Categories" />
              </ListItemButton>
            </ListItem>
            <ListItem disablePadding>
              <ListItemButton
                component={Link}
                href="/Main/Product/ProductList"
                selected={pathname.includes("/Product/ProductList")}
              >
                <ListItemIcon>
                  <InboxIcon sx={{ color: "silver" }} />
                </ListItemIcon>
                <ListItemText primary="Products" />
              </ListItemButton>
            </ListItem>
          </List>
          <Divider />
        </Box>
      </Drawer>

      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar />
        {children}
      </Box>
      <ToastContainer />
    </Box>
  );
}
