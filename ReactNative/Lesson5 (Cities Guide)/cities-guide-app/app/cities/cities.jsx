// app/cities.jsx
import { StyleSheet, FlatList, TouchableOpacity, Image, View } from "react-native";
import { Link } from "expo-router";
import { ThemedView } from "../../components/ThemedView";
import { ThemedText } from "../../components/ThemedText";
import { citiesData } from "../../constants/citiesData";
import city from "../../assets/city.png";

export default function Cities() {
  return (
    <ThemedView style={styles.container}>
      <FlatList
        data={citiesData}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => (
          <Link href={`/cities/${item.id}`} asChild>
            <TouchableOpacity style={styles.card}>
              <Image source={city} style={styles.image} />
              <View style={styles.info}>
                <ThemedText style={styles.name}>{item.name}</ThemedText>
                <ThemedText style={styles.desc}>{item.description}</ThemedText>
                <ThemedText style={styles.population}>
                  Population: {item.population}
                </ThemedText>
              </View>
            </TouchableOpacity>
          </Link>
        )}
      />
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 10 },
  card: {
    flexDirection: "row",
    alignItems: "center",
    backgroundColor: "#eee",
    borderRadius: 12,
    marginVertical: 8,
    padding: 10,
  },
  image: { width: 80, height: 80, borderRadius: 10, marginRight: 12 },
  info: { flex: 1 },
  name: { fontSize: 18, fontWeight: "bold", color: "#000000ff" },
  desc: { fontSize: 14, color: "#000000ff" },
  population: { fontSize: 12, marginTop: 5, color: "#000000ff" },
});
