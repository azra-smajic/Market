"use client";
import { useRouter } from "next/navigation";
import React, { createContext, useContext, useEffect, useState } from "react";
import config from "../config";
import { getItemWithExpiry, setItemWithExpiry } from "../util/tokenStorage";

interface AuthContextType {
  user: any;
  login: (
    email: string,
    password: string
  ) => Promise<{ status: string; error?: string }>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({
  children,
}) => {
  const [user, setUser] = useState<any>(null);

  const login = async (email: string, password: string) => {
    try {
      const res = await fetch(`${config.API_BASE_URL}/Access/SignIn`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ Username: email, Password: password }),
      });

      if (!res.ok) {
        return { status: "error", error: "Neispravni podaci" };
      }
      const data = await res.json();
      setUserData(data);
      return { status: "success" };
    } catch (error) {
      return { status: "error", error: "Greška kod prijave" };
    }
  };

  const setUserData = (data: any) => {
    setItemWithExpiry(
      config.AUTH_TOKEN_KEY,
      data.token,
      data.expireTime * 60 * 1000 // Converting to miliseconds
    );

    setItemWithExpiry(
      config.MARKET_ID,
      data.marketId,
      data.expireTime * 60 * 1000 // Converting to miliseconds
    );
  };

  const logout = () => {
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within an AuthProvider");
  return context;
};

export const useAuthGuard = () => {
  const router = useRouter();

  useEffect(() => {
    const tokenStr = getItemWithExpiry(config.AUTH_TOKEN_KEY);
    const marketId = getItemWithExpiry(config.MARKET_ID);
    if (!tokenStr) {
      router.push("/");
      return;
    }
  }, []);
};
