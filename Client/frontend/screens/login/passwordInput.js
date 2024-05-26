import React from 'react';
import { TextInput, View } from 'react-native';
import styles from './styles';

const PasswordInput = ({ value, onChangeText, placeholder }) => {
  return (
    <View>
      <TextInput
        style={styles.Input}
        value={value}
        onChangeText={onChangeText}
        placeholder={placeholder}
        secureTextEntry={true}
      />
    </View>
  );
};

export default PasswordInput;
