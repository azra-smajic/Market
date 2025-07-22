"use client";

import { AppProvider } from "@toolpad/core/AppProvider";
import { SignInPage } from "@toolpad/core/SignInPage";
import { useRouter } from "next/navigation";
import { useAuth } from "../Providers/AuthProvider";

const providers = [{ id: "credentials", name: "Credentials" }];

const BRANDING = {
  logo: <img src="/logo-login.png" alt="MUI logo" style={{ height: 200 }} />,
  title: "MarketManager",
};

export default function BrandingSignInPage() {
  const { login } = useAuth();
  const router = useRouter();

  const signIn = async (provider: any, formData: any) => {
    const result = await login(formData.get("email"), formData.get("password"));
    if (result.status === "success") {
      router.push("/Main");
    }
    return result;
  };

  return (
    <AppProvider branding={BRANDING}>
      <SignInPage
        providers={providers}
        signIn={signIn}
        slotProps={{
          emailField: { autoFocus: false },
          form: { noValidate: true },
        }}
      />
    </AppProvider>
  );
}
