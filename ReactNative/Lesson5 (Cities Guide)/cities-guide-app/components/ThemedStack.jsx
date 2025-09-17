import { Stack } from "expo-router";
import { ThemeContext } from "../context/ThemeContext";
import { useContext } from "react";
import { ThemedStatusBar } from "../components/ThemedStatusBar";

export function ThemedStack() {
  const { theme } = useContext(ThemeContext);

  return (
    <>
      <Stack
        screenOptions={{
          headerStyle: { backgroundColor: theme.navbarBgColor },
          headerTintColor: theme.navbarTextColor,
          title: "About Me App",
        }}
      />
    </>
  );
}