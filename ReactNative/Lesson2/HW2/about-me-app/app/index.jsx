import { Link } from "expo-router";
import { StyleSheet, useColorScheme } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../context/ThemeContext";
import { ThemedView } from "../components/ThemedView";
import { ThemedText } from "../components/ThemedText";
import { StatusBar } from "expo-status-bar";

export default function Home() {
  const { theme } = useContext(ThemeContext);

  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>Welcome to My App 🎉</ThemedText>
      <Link href="/info" style={styles.link}>
        <ThemedText>Go to Info</ThemedText>
      </Link>
      <Link href="/hobbies" style={styles.link}>
        <ThemedText>Go to Hobbies</ThemedText>
      </Link>
      <Link href="/settings" style={styles.link}>
        <ThemedText>Go to Settings</ThemedText>
      </Link>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 20 },
  link: { fontSize: 18, marginVertical: 10 },
});
