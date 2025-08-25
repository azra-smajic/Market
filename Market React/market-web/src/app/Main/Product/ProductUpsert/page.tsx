"use client";
import {
  Box,
  Button,
  Grid,
  MenuItem,
  Paper,
  Step,
  StepLabel,
  Stepper,
  Switch,
  TextField,
  Typography,
} from "@mui/material";
import React, { useState } from "react";

const categories = ["Electronics", "Clothes", "Books"];
const currencies = ["EUR", "USD", "BAM"];

const steps = ["Basic Info", "Price Details", "Status"];

const ProductAddPage: React.FC = () => {
  const [activeStep, setActiveStep] = useState(0);
  const [images, setImages] = useState<File[]>([]);
  const [formData, setFormData] = useState({
    name: "",
    sku: "",
    category: "",
    description: "",
    price: 0,
    currency: "EUR",
    discount: 0,
    active: true,
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  const handleNumberChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: parseFloat(value) || 0 }));
  };

  const handleImageUpload = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setImages(Array.from(e.target.files));
    }
  };

  const handleNext = () => setActiveStep((prev) => prev + 1);
  const handleBack = () => setActiveStep((prev) => prev - 1);

  const handleSubmit = () => {
    console.log("Saving product:", formData);
    console.log("Images:", images);
  };

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#f5f5f5", // opcionalno, za ljepši izgled
        p: 2,
      }}
    >
      <Grid container spacing={2}>
        <Grid item xs={4}>
          <Paper
            sx={{
              width: 300, // ili fiksna širina, npr. 300px
              height: "60%", // visina skoro kao tvoja max image
              border: "2px dashed #ccc",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              cursor: "pointer",
              textAlign: "center",
              p: 2,
              "&:hover": { borderColor: "#999" },
            }}
            onClick={() => document.getElementById("image-input")?.click()}
            onDrop={(e) => {
              e.preventDefault();
              if (e.dataTransfer.files) {
                setImages(Array.from(e.dataTransfer.files));
              }
            }}
            onDragOver={(e) => e.preventDefault()}
          >
            {images.length === 0 ? (
              <Typography>Click or Drop Image</Typography>
            ) : (
              <Box
                sx={{
                  display: "flex",
                  flexDirection: "column",
                  alignItems: "center",
                  gap: 1,
                }}
              >
                {images.map((img, i) => (
                  <Typography key={i} variant="body2">
                    {img.name}
                  </Typography>
                ))}
              </Box>
            )}
          </Paper>

          <input
            type="file"
            id="image-input"
            hidden
            multiple
            accept="image/*"
            onChange={(e) => {
              if (e.target.files) setImages(Array.from(e.target.files));
            }}
          />
        </Grid>

        {/* RIGHT STEPPER */}
        <Grid item xs={8}>
          <Paper sx={{ p: 3, width: 800 }}>
            <Stepper activeStep={activeStep} alternativeLabel>
              {steps.map((label) => (
                <Step key={label}>
                  <StepLabel>{label}</StepLabel>
                </Step>
              ))}
            </Stepper>

            <Box mt={4} sx={{ height: "250px" }}>
              {activeStep === 0 && (
                <Box>
                  <Grid
                    container
                    spacing={2}
                    sx={{ display: "flex", flexDirection: "column" }}
                  >
                    <Box
                      sx={{
                        display: "flex",
                        flexDirection: "row",
                        justifyContent: "space-between",
                      }}
                    >
                      <Grid item xs={6} sx={{ width: "49%" }}>
                        <TextField
                          fullWidth
                          label="Product Name"
                          name="name"
                          value={formData.name}
                          onChange={handleChange}
                        />
                      </Grid>
                      <Grid item xs={6} sx={{ width: "49%" }}>
                        <TextField
                          fullWidth
                          label="SKU"
                          name="sku"
                          value={formData.sku}
                          onChange={handleChange}
                        />
                      </Grid>
                    </Box>

                    <Grid item xs={12}>
                      <TextField
                        select
                        fullWidth
                        label="Category"
                        name="category"
                        value={formData.category}
                        onChange={handleChange}
                      >
                        {categories.map((c) => (
                          <MenuItem key={c} value={c}>
                            {c}
                          </MenuItem>
                        ))}
                      </TextField>
                    </Grid>
                    <Grid item xs={12}>
                      <TextField
                        fullWidth
                        multiline
                        minRows={3}
                        label="Description"
                        name="description"
                        value={formData.description}
                        onChange={handleChange}
                      />
                    </Grid>
                  </Grid>
                </Box>
              )}

              {activeStep === 1 && (
                <Grid
                  container
                  spacing={2}
                  sx={{
                    display: "flex",
                    justifyContent: "center",
                    flexDirection: "column",
                  }}
                >
                  <Box
                    sx={{
                      display: "flex",
                      flexDirection: "row",
                      justifyContent: "space-between",
                    }}
                  >
                    <Grid
                      item
                      xs={4}
                      sx={{
                        width: "49%",
                      }}
                    >
                      <TextField
                        fullWidth
                        type="number"
                        label="Price"
                        name="price"
                        value={formData.price}
                        onChange={handleNumberChange}
                      />
                    </Grid>
                    <Grid
                      item
                      xs={4}
                      sx={{
                        width: "49%",
                      }}
                    >
                      <TextField
                        select
                        fullWidth
                        label="Currency"
                        name="currency"
                        value={formData.currency}
                        onChange={handleChange}
                      >
                        {currencies.map((c) => (
                          <MenuItem key={c} value={c}>
                            {c}
                          </MenuItem>
                        ))}
                      </TextField>
                    </Grid>
                  </Box>
                  <Grid
                    item
                    xs={4}
                    sx={{
                      width: "49%",
                    }}
                  >
                    <TextField
                      fullWidth
                      type="number"
                      label="Discount"
                      name="discount"
                      value={formData.discount}
                      onChange={handleNumberChange}
                    />
                  </Grid>
                </Grid>
              )}

              {activeStep === 2 && (
                <Box
                  sx={{
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                  }}
                >
                  <Switch
                    checked={formData.active}
                    onChange={(e) =>
                      setFormData((prev) => ({
                        ...prev,
                        active: e.target.checked,
                      }))
                    }
                  />
                  <Typography
                    variant="body2"
                    sx={{ mt: 1, color: "text.secondary" }}
                  >
                    ⚠️ This is a dangerous operation. Deactivated products will
                    not be visible on page.
                  </Typography>
                </Box>
              )}
            </Box>

            {/* Navigation buttons */}
            <Box mt={4} display="flex" justifyContent="space-between">
              <Button
                disabled={activeStep === 0}
                onClick={handleBack}
                variant="outlined"
              >
                Back
              </Button>
              {activeStep < steps.length - 1 && (
                <Button variant="contained" onClick={handleNext}>
                  Next
                </Button>
              )}
              {activeStep == 2 && (
                <Button
                  variant="contained"
                  color="primary"
                  onClick={handleSubmit}
                >
                  Save Product
                </Button>
              )}
            </Box>
          </Paper>
        </Grid>
      </Grid>
    </Box>
  );
};

export default ProductAddPage;
