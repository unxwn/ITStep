import { View } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../contexts/ThemeContext";

export function ThemedView({ style, children, ...props }) {
  const { theme } = useContext(ThemeContext);
  
  return (
    <View style={[{ backgroundColor: theme.backgroundColor }, style]} {...props}>
      {children}
    </View>
  );
}
