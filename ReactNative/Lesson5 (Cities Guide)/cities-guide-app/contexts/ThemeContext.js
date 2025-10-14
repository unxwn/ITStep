import { createContext, useState, useEffect, useCallback } from "react";
import { useColorScheme } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";

export const ThemeContext = createContext();

const STORAGE_KEY = "@cities_theme_v1"; // ключ для AsyncStorage

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
  const [ready, setReady] = useState(false);

  useEffect(() => {
    (async () => {
      try {
        const raw = await AsyncStorage.getItem(STORAGE_KEY);
        if (raw) {
          const parsed = JSON.parse(raw);
          // Якщо в сховищі збережено лише частину теми
          setTheme((prev) => ({ ...prev, ...parsed }));
        }
      } catch (err) {
        console.warn("Failed to load theme from storage", err);
      } finally {
        setReady(true);
      }
    })();
  }, []);

  // Функція, яка встановлює тему і зберігає її в AsyncStorage
  const setThemeState = useCallback(
    async (next) => {
      try {
        const nextTheme =
          typeof next === "function" ? next(theme) : { ...theme, ...next };
        setTheme(nextTheme);
        await AsyncStorage.setItem(STORAGE_KEY, JSON.stringify(nextTheme));
      } catch (err) {
        console.warn("Failed to save theme to storage", err);
      }
    },
    [theme]
  );

  return (
    <ThemeContext.Provider value={{ theme, setThemeState, ready }}>
      {children}
    </ThemeContext.Provider>
  );
};

export default ThemeProvider;
