import { createContext, useState } from "react";
import { useColorScheme } from "react-native";

export const ThemeContext = createContext();

const ThemeProvider = ({ children }) => {
  const colorScheme = useColorScheme();

  const defaultDarkTheme = {
    backgroundColor: "black",
    textColor: "white",
    navbarBgColor: "#2c2c2fff",
    navbarTextColor: "white",
    borderColor: "#3a3a3c",
    inputBgColor: "#3b3b3bff",
  };

  const defaultLightTheme = {
    backgroundColor: "white",
    textColor: "black",
    navbarBgColor: "f2f2f7",
    navbarTextColor: "black",
    borderColor: "#d1d1d6",
    inputBgColor: "#adadb4ff",
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

export default ThemeProvider;
