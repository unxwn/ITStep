import { View, Text, StyleSheet } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../context/ThemeContext";
import { ThemedText } from "../components/ThemedText";
import { ThemedView } from "../components/ThemedView";

export default function Hobbies() {
  const { theme } = useContext(ThemeContext);

  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>My Hobbies</ThemedText>
      <ThemedText style={styles.text}>- Basketball</ThemedText>
      <ThemedText style={styles.text}>- Counter Strike 2</ThemedText>
      <ThemedText style={styles.text}>- Riding</ThemedText>
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
  },
  title: { fontSize: 22, fontWeight: "bold", marginBottom: 10 },
  text: { fontSize: 18, marginVertical: 5 },
});
