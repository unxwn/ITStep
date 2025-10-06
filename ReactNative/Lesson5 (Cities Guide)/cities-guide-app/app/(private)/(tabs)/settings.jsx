import React from "react";
import { StyleSheet } from "react-native";
import Slider from "@react-native-community/slider";
import { View, Text } from "react-native";
import { useContext, useState } from "react";
import { ThemeContext } from "../../../contexts/ThemeContext";
import { ThemedText } from "../../../components/ThemedText";
import { ThemedView } from "../../../components/ThemedView";

export default function Settings() {
  const { theme, setTheme } = useContext(ThemeContext);

  const [bg, setBg] = useState(parseColorToArray(theme?.backgroundColor, [255, 255, 255]));
  const [txt, setTxt] = useState(parseColorToArray(theme?.textColor, [0, 0, 0]));
  const [border, setBorder] = useState(parseColorToArray(theme?.borderColor, [100, 100, 100]));

  const groups = [
    { key: "bg", label: "Background", arr: bg, setter: setBg, themeKey: "backgroundColor" },
    { key: "txt", label: "Text", arr: txt, setter: setTxt, themeKey: "textColor" },
    { key: "border", label: "Border", arr: border, setter: setBorder, themeKey: "borderColor" },
  ];

  const onSliderChange = (groupKey, index, value) => {
    const g = groups.find((x) => x.key === groupKey);
    if (!g) return;
    const newArr = [...g.arr];
    newArr[index] = Math.round(value);
    g.setter(newArr);

    setTheme({
      ...theme,
      [g.themeKey]: rgbString(newArr),
    });
  };
 
  return (
    <ThemedView style={styles.container}>
      <ThemedText style={styles.title}>🎨 Settings</ThemedText>

      {groups.map((g) => (
        <React.Fragment key={g.key}>
          <ThemedText style={{ marginTop: 8 }}>{g.label}</ThemedText>
          {["R", "G", "B"].map((c, i) => (
            <Slider
              key={`${g.key}-${c}`}
              minimumValue={0}
              maximumValue={255}
              step={1}
              value={g.arr[i]}
              onValueChange={(val) => onSliderChange(g.key, i, val)}
            />
          ))}
        </React.Fragment>
      ))}

      <Text style={{ marginTop: 16, marginBottom: 6 }}>Preview:</Text>
      <View
        style={{
          padding: 12,
          borderWidth: 1,
          borderRadius: 8,
          borderColor: rgbString(border),
          backgroundColor: rgbString(bg),
        }}
      >
        <Text style={{ color: rgbString(txt), fontWeight: "600" }}>This is a preview</Text>
        <Text style={{ color: rgbString(txt) }}>Text color and background update instantly.</Text>
      </View>
    </ThemedView>
  );
}

const rgbString = (arr) => `rgb(${arr[0]},${arr[1]},${arr[2]})`;

const hexToRgbArray = (hex) => {
  let h = hex.replace("#", "");
  if (h.length === 3) h = h.split("").map((c) => c + c).join("");
  const r = parseInt(h.slice(0, 2), 16);
  const g = parseInt(h.slice(2, 4), 16);
  const b = parseInt(h.slice(4, 6), 16);
  return [r, g, b];
};

const parseColorToArray = (color, fallback = [255, 255, 255]) => {
  if (!color) return fallback;
  const c = color.toString().trim().toLowerCase();
  if (c.startsWith("rgb")) {
    const nums = c.match(/\d+/g);
    if (nums && nums.length >= 3) return nums.slice(0, 3).map((n) => Number(n));
    return fallback;
  }
  if (c.startsWith("#")) {
    try {
      return hexToRgbArray(c);
    } catch {
      return fallback;
    }
  }
  if (c === "white") return [255, 255, 255];
  if (c === "black") return [0, 0, 0];
  return fallback;
};

const styles = StyleSheet.create({
  container: { flex: 1, padding: 20 },
  title: { fontSize: 24, fontWeight: "bold", marginBottom: 20 },
});
