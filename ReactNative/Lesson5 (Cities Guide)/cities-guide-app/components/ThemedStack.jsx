import { Stack } from "expo-router";
import { ThemeContext } from "../contexts/ThemeContext";
import { useContext } from "react";

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