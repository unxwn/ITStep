import { Stack, Slot } from "expo-router";
import { ThemeProvider, ThemeContext } from "../context/ThemeContext";
import { ThemedStack } from "../components/ThemedStack";
import { useContext } from "react";
import { ThemedStatusBar } from "../components/ThemedStatusBar";



export default function Layout() {
  return (
    <ThemeProvider>
      <ThemedStatusBar />
      <ThemedStack />
      {/* <Slot/> */}
    </ThemeProvider>
  );
}