import { createContext, useState } from "react";
import { useColorScheme } from "react-native";

export const ThemeContext = createContext();

export const ThemeProvider = ({ children }) => {
  const colorScheme = useColorScheme();

  const defaultDarkTheme = {
    backgroundColor: "black",
    textColor: "white",
    navbarBgColor: "#1c1c1e",
    navbarTextColor: "white",
    borderColor: "#3a3a3c",
  };

  const defaultLightTheme = {
    backgroundColor: "white",
    textColor: "black",
    navbarBgColor: "f2f2f7",
    navbarTextColor: "black",
    borderColor: "#d1d1d6",
  }
  
  const [theme, setTheme] = useState(
    colorScheme === "dark" ? defaultDarkTheme : defaultLightTheme
  );

  return (
    <ThemeContext.Provider value={{ theme, setTheme }}>
      {children}
    </ThemeContext.Provider>
  );
};
