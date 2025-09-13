import { createContext, useState } from "react";
import { useColorScheme } from "react-native";

export const ThemeContext = createContext();

export const ThemeProvider = ({ children }) => {
  const colorScheme = useColorScheme();
  
  const [theme, setTheme] = useState(
    colorScheme === "dark"
      ? { backgroundColor: "black", textColor: "white", navbarBgColor: "#1c1c1e", navbarTextColor: "white" }
      : { backgroundColor: "white", textColor: "black", navbarBgColor: "#f2f2f7", navbarTextColor: "black" }
  );

  return (
    <ThemeContext.Provider value={{ theme, setTheme }}>
      {children}
    </ThemeContext.Provider>
  );
};
