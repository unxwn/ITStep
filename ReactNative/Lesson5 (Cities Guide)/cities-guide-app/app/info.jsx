import { StyleSheet } from "react-native";
import { Link } from "expo-router";
import { ThemedText } from "../components/ThemedText";
import { ThemedView } from "../components/ThemedView";

export default function Info() {
  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>
        👤 My Info
      </ThemedText>
      <ThemedText style={styles.text}>
        Name: Myroslav Polishchuk
      </ThemedText>
      <ThemedText style={styles.text}>
        Phone: +222 0123456897
      </ThemedText>
      <ThemedText style={styles.text}>
        Email: myrospolil@gmail.com
      </ThemedText>
      <ThemedText style={styles.text}>
        Location: London
      </ThemedText>

      <Link href="/" style={styles.link}>
        <ThemedText style={styles.link}>Go Home</ThemedText>
      </Link>

    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center"
  },
  title: { fontSize: 22, fontWeight: "bold", marginBottom: 10 },
  text: { fontSize: 18, marginVertical: 5 },
  link: { fontSize: 18, marginVertical: 100, color: 'cadetblue', textDecorationLine: "underline" },
});
