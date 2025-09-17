import { Link } from "expo-router";
import { StyleSheet, View, Text } from "react-native";
import { ThemedView } from "../../components/ThemedView";
import { ThemedText } from "../../components/ThemedText";

export default function Home() {
  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>Welcome to My App 🎉</ThemedText>
      <Link href="/cities/cities" style={styles.link}>
        <ThemedText>Go to Cities Guide page</ThemedText>
      </Link>
      <Link href="/info" style={styles.link}>
        <ThemedText>Go to Info</ThemedText>
      </Link>
      <Link href="/hobbies" style={styles.link}>
        <ThemedText>Go to Hobbies</ThemedText>
      </Link>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 20 },
  link: { fontSize: 18, marginVertical: 10 },
});
