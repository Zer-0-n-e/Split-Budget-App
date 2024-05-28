import { HelloWave } from "@/components/HelloWave";
import { Text, View } from "react-native";
import LoginButton from '../../components/button/loginButton';
import styles from './styles.js'
import { TextInput } from "react-native-gesture-handler";
import PasswordInput from  './passwordInput'
import { useState } from "react";

const Login = (props) => {
    const [password, setPassword] = useState('');
    const [userID, setUserID] = useState('')

    const handleLoginPress = () => {
        console.log("Login pressed", userID, " ", password);
    }

    return (<View style={styles.mainView}>
        <Text>Username/UserID</Text>
        <TextInput style={styles.Input} value={userID}
        onChangeText={setUserID}
        placeholder="Enter user Name"></TextInput>
        <Text >Password</Text>
        <PasswordInput value={password}
          onChangeText={setPassword}
          placeholder="Enter your password"/>
        <LoginButton onPress={handleLoginPress} />
        <HelloWave />
    </View>
    );
}

export default Login;