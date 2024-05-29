import React from 'react';
import { TouchableOpacity, Text, StyleSheet } from 'react-native';
import styles from './styles';

const SignUpButton = ({ onPress }) => {
  return (
    <TouchableOpacity style={styles.button} onPress={onPress}>
      <Text style={styles.buttonText}>Sign-Up</Text>
    </TouchableOpacity>
  );
};

export default SignUpButton;
