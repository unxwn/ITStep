import { Text } from "react-native";
import { useContext } from "react";
import { ThemeContext } from "../contexts/ThemeContext";

export function ThemedText({ style, ...props }) {
  const { theme } = useContext(ThemeContext);

  return (
    <Text 
      style={[{ color: theme.textColor }, style]} 
      {...props} 
    />
  );
}
