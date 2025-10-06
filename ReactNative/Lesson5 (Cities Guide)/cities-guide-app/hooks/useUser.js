import { useContext } from "react";
import { AuthContext } from "../contexts/AuthContext";

export const useUser = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("AuthContext not found. Wrap app with AuthProvider.");
  return context;
};
