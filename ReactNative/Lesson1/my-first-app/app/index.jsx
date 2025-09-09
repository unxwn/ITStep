import { Link } from "expo-router"
import { Text, View } from "react-native"

const Index = () => {
    return(
        <View style={{flex: 1, justifyContent: "center", alignItems: "center"}}>
            <Text>Привіт від React Native</Text>
            <Link href="/about">Про додаток</Link>
        </View>
    )
}

export default Index;