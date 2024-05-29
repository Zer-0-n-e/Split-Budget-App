import { HelloWave } from "@/components/HelloWave";
import { Text, View } from "react-native";
import { useRouter } from "expo-router";
import styles from './styles.js'
import { TextInput } from "react-native-gesture-handler";
import PasswordInput from '../../components/passwordInput.js'
import { useState } from "react";
import SignUpButton from "../../components/button/signUpButton/index.js";

const SignUp = (props) => {
    const [password, setPassword] = useState('');
    const [gmail, setGmail] = useState('');
    const [userName, setUserName] = useState('');
    const [contactNum, setContactNum] = useState('');

    const router = useRouter();

    const handleSignUpPress = () => {
        console.log("SignUp pressed", userName, " ", gmail, " ", contactNum, " ", password);
        router.push('/login');
    }

    return (<View style={styles.mainView}>
        <Text>Username/UserID</Text>
        <TextInput style={styles.Input} value={userName}
            onChangeText={setUserName}
            placeholder="Enter user Name"></TextInput>
        <Text>Gmail-ID</Text>
        <TextInput style={styles.Input} value={gmail}
            onChangeText={setGmail}
            placeholder="Enter Gmail"></TextInput>
        <Text>Contact Number</Text>
        <TextInput style={styles.Input} value={contactNum}
            onChangeText={setContactNum}
            placeholder="0-9"></TextInput>
        <Text >Password</Text>
        <PasswordInput value={password}
            onChangeText={setPassword}
            placeholder="Enter your password" />
        <SignUpButton onPress={handleSignUpPress} />
        <HelloWave />
    </View>
    );
}

export default SignUp;