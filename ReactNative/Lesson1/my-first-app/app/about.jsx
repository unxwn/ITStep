import { Link } from "expo-router";
import { StyleSheet, View, Text } from "react-native"

const About = () => {
    return(
        <View style={styles.container}>
            <Text>About</Text>
            <Text>v. 0.1.0</Text>
            <Text>Author: Myroslav Polishchuk</Text>
            <Text>Created with React Native</Text>
            <Link href="/">Go back home</Link>
        </View>
    )
}

export default About;

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
        backgroundColor: "#747474ff"
    }
})