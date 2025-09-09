import { StyleSheet, Text, View } from 'react-native';

export default function App() {
  return (
    <View style={styles.container}>
      <View style={styles.top}>
        <Text style={styles.title}>Info</Text>
        <Text style={styles.text}>Name: Myroslav Polishchuk</Text>
        <Text style={styles.text}>Phone: +222 0123456897</Text>
        <Text style={styles.text}>Email: myrospolil@gmail.com</Text>
        <Text style={styles.text}>Location: London</Text>
      </View>

      <View style={styles.bottom}>
        <Text style={styles.title}>Hobbies</Text>
        <Text style={styles.text}>- Basketball</Text>
        <Text style={styles.text}>- Counter Strike 2</Text>
        <Text style={styles.text}>- Riding</Text>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f0f0f0",
  },
  top: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#0059ffff",
  },
  bottom: {
    flex: 1,
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#ffd64fff",
  },
  title: {
    fontSize: 22,
    fontWeight: "bold",
    marginBottom: 10,
  },
  text: {
    fontSize: 18,
    marginVertical: 3,
  },
});
