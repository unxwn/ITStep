import { View } from "react-native";

export function Spacer({ height = 8, width = 0 }) {
  return <View style={{ height, width }} />;
}
