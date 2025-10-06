import { Tabs } from "expo-router";
import { useContext } from "react";
import { ThemeContext } from "../../../contexts/ThemeContext";
import Ionicons from "@expo/vector-icons/Ionicons";

export default function TabsLayout() {
  const { theme } = useContext(ThemeContext);

  return (
    <Tabs
      screenOptions={({ route }) => ({
        headerShown: true,
        tabBarActiveTintColor: theme?.navbarTextColor ?? "black",
        tabBarStyle: { backgroundColor: theme?.navbarBgColor ?? "#fff" },
        tabBarIcon: ({ color, size }) => {
          let name = "ellipse";
          if (route.name === "index") name = "home-outline";
          if (route.name === "settings") name = "settings-outline";
          return <Ionicons name={name} size={size} color={color} />;
        },
      })}
    >
      <Tabs.Screen name="index" options={{ title: "Home" }} />
      <Tabs.Screen name="settings" options={{ title: "Settings" }} />
    </Tabs>
  );
}
