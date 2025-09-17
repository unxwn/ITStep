// app/cities/[id].jsx
import { useLocalSearchParams } from "expo-router";
import { StyleSheet, View, Image } from "react-native";
import { ThemedView } from "../../components/ThemedView";
import { ThemedText } from "../../components/ThemedText";
import { citiesData } from "../../constants/citiesData";
import citypng from "../../assets/city.png";
 
export default function CityDetails() {
  const { id } = useLocalSearchParams();
  const city = citiesData.find((c) => c.id.toString() === id);

  if (!city) {
    return (
      <ThemedView style={styles.container}>
        <ThemedText>City not found ❌</ThemedText>
      </ThemedView>
    );
  }

  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>{city.name}</ThemedText>
      <Image source={citypng} style={styles.image} />
      <ThemedText style={styles.text}>{city.description}</ThemedText>
      <ThemedText style={styles.text}>Population: {city.population}</ThemedText>
      <ThemedText style={styles.text}>Country: {city.country}</ThemedText>
      {city.region && (
        <ThemedText style={styles.text}>Region: {city.region}</ThemedText>
      )}
    </ThemedView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20 },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 15 },
  text: { fontSize: 16, marginVertical: 5 },
  image: { width: "100%", height: 200, borderRadius: 12, marginBottom: 15 },
});
