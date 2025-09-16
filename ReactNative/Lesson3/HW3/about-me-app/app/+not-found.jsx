import { Link } from "expo-router";
import { StyleSheet } from "react-native";
import { ThemedView } from "../components/ThemedView";
import { ThemedText } from "../components/ThemedText";

export default function NotFound() {
  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>404 — Page not found</ThemedText>
      <Link href="/(tabs)/index">
        <ThemedText>Go to Home</ThemedText>
      </Link>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 20, fontWeight: "700", marginBottom: 12 },
});
