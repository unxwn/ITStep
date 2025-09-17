import { View } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../context/ThemeContext";

export function ThemedView({ style, children, ...props }) {
  const { theme } = useContext(ThemeContext);
  
  return (
    <View style={[{ backgroundColor: theme.backgroundColor }, style]} {...props}>
      {children}
    </View>
  );
}
