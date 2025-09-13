import { Stack } from "expo-router";
import { ThemeProvider, ThemeContext } from "../context/ThemeContext";
import { useContext } from "react";
import { ThemedStatusBar } from "../components/ThemedStatusBar";

function ThemedStack() {
  const { theme } = useContext(ThemeContext);

  return (
    <>
      <ThemedStatusBar />
      <Stack
        screenOptions={{
          headerStyle: { backgroundColor: theme.navbarBgColor },
          headerTintColor: theme.navbarTextColor,
        }}
      />
    </>
  );
}

export default function Layout() {
  return (
    <ThemeProvider>
      <ThemedStack />
    </ThemeProvider>
  );
}