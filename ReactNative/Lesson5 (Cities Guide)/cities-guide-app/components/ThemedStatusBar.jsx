import { StatusBar } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../context/ThemeContext";
import Color from "color";

export function ThemedStatusBar() {
  const { theme } = useContext(ThemeContext);
  
  const brightness = Color(theme.backgroundColor).luminosity();

  return (
    <StatusBar
      barStyle={brightness > 0.5 ? "dark-content" : "light-content"}
      backgroundColor={theme.backgroundColor}
    />
  );
}
