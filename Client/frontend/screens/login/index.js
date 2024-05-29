import { HelloWave } from "@/components/HelloWave";
import { useRouter } from 'expo-router';
import { Text, TouchableOpacity, View } from "react-native";
import LoginButton from '../../components/button/loginButton/index.js';
import styles from './styles.js'
import { TextInput } from "react-native-gesture-handler";
import PasswordInput from '../../components/passwordInput.js'
import { useState } from "react";

const Login = (props) => {
    const [password, setPassword] = useState('');
    const [userID, setUserID] = useState('')
    const router = useRouter();

    const handleLoginPress = () => {
        console.log("Login pressed", userID, " ", password);
        router.push('/home');
    }

    const onPressHandler = () => {
        router.push('/signup');
    }

    return (<View style={styles.mainView}>
        <Text>Username/UserID</Text>
        <TextInput style={styles.Input} value={userID}
            onChangeText={setUserID}
            placeholder="Enter user Name"></TextInput>
        <Text >Password</Text>
        <PasswordInput value={password}
            onChangeText={setPassword}
            placeholder="Enter your password" />
        <LoginButton onPress={handleLoginPress} />
        <HelloWave />
        <TouchableOpacity onPress={onPressHandler}>
            <Text>Do not have account, click to create one!!</Text>
        </TouchableOpacity>
    </View>
    );
}

export default Login;