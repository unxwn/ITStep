import { StyleSheet } from "react-native";
import { ThemedText } from "../components/ThemedText";
import { ThemedView } from "../components/ThemedView";

export default function Settings() {
  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>🎨 Settings</ThemedText>
      <ThemedText>Theme selection coming soon!</ThemedText>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20 },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 20 },
});
