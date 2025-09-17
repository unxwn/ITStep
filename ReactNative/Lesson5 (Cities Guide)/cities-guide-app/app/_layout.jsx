import { Stack, Slot } from "expo-router";
import { ThemeProvider, ThemeContext } from "../context/ThemeContext";
import { ThemedStack } from "../components/ThemedStack";
import { useContext } from "react";
import { ThemedStatusBar } from "../components/ThemedStatusBar";
import { GestureHandlerRootView } from "react-native-gesture-handler";


export default function Layout() {
  return (
    <GestureHandlerRootView style={{ flex: 1 }}>
      <ThemeProvider>
        <ThemedStatusBar />
        <ThemedStack />
        {/* <Slot/> */}
      </ThemeProvider>
    </GestureHandlerRootView>
  );
}