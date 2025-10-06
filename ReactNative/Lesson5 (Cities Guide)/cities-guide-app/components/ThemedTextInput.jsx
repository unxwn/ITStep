import { useContext } from "react";
import { TextInput, StyleSheet } from "react-native";
import { ThemeContext } from "../contexts/ThemeContext";

export function ThemedTextInput(props) {
    const { theme } = useContext(ThemeContext) || {};
    const inputStyle = {
        backgroundColor: theme?.inputBgColor ?? "green",
        color: theme?.textColor ?? "#ef0000ff",
        borderColor: theme?.borderColor ?? "#ccc",
    };
    
    const { style, ...rest } = props;

    return <TextInput {...rest} style={[styles.input, inputStyle, style]} />
}

const styles = StyleSheet.create({
    input: {
        height: 44,
        paddingHorizontal: 12,
        borderWidth: 1,
        borderRadius: 8,
    },
});
