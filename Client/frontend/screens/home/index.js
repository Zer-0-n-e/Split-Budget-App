import React from "react";
import { Text, View } from "react-native-web";
import { HelloWave } from "@/components/HelloWave";
import styles from "./styles"

const Home = (props) => {
    return (
    <View style={styles.mainView}>
        <Text>Welcome Home</Text>
        <HelloWave />
    </View>
    );
}

export default Home;