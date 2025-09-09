import { Slot, Stack } from "expo-router";
import { StatusBar } from "expo-status-bar";
import { View, StyleSheet, Text } from "react-native";

const RootLayout = () => {
  return (
    <View>
      <StatusBar style="auto" />
      <Stack style={styles.container}
        screenOptions={{
          contentStyle: { backgroundColor: "#d60000ff" },
            headerStyle: { backgroundColor: "#00ff00ff" },
            headerTintColor: "#0000ffff",
            headerTitleStyle: { 
                fontWeight: "bold",
                color: "#ffffff"
            }
        }}
      >
        <Stack.Screen name="index" options={{ headerTitle: "Home" }} />
        <Stack.Screen name="about" options={{ headerTitle: "About" }} />
      </Stack>
      <View style={styles.сontainer}>
        <Text>Footer</Text>
      </View>
    </View>
  );
};

export default RootLayout;

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#aaa"
    }
})