import { Link,router } from "expo-router";
import { useState } from "react";
import { Button } from "react-native";
import { StyleSheet, View, Text } from "react-native";
import { ThemedView } from "../../../components/ThemedView";
import { ThemedText } from "../../../components/ThemedText";
import AuthContext from "../../../contexts/AuthContext";
import { useUser } from "../../../hooks/useUser";

export default function Home() {
  const { logout, loading } = useUser();
  const [busy, setBusy] = useState(false);

  const handleLogout = async () => {
    if (busy) return;
    setBusy(true);
    try {
      await logout();
      router.replace("/login");
    } catch (err) {
      console.error("Logout failed", err);
      Alert.alert("Помилка", err.message || "Не вдалось вийти");
    } finally {
      setBusy(false);
    }
  };

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
      <Button title="Log out" onPress={handleLogout} disabled={busy || loading} />

    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: "center", alignItems: "center" },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 20 },
  link: { fontSize: 18, marginVertical: 10 },
});
