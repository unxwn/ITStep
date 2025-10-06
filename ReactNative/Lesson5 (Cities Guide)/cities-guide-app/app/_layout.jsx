import { Slot } from "expo-router";
import ThemeProvider from "../contexts/ThemeContext";
import AuthProvider from "../contexts/AuthContext";
// import { ThemedStack } from "../components/ThemedStack";
import { ThemedStatusBar } from "../components/ThemedStatusBar";
import { GestureHandlerRootView } from "react-native-gesture-handler";


export default function Layout() {
  return (
    <GestureHandlerRootView style={{ flex: 1 }}>
      <ThemeProvider>
        <AuthProvider>
          <ThemedStatusBar />
          {/* <ThemedStack /> */}
          <Slot/>
        </AuthProvider>
      </ThemeProvider>
    </GestureHandlerRootView>
  );
}