import Login from  '../screens/login'

export default function Index() {

  const handleLoginPress = () => {
    Alert.alert('Login Button Pressed', 'Handle your login logic here.');
  };

  return (
    <Login />
  );
}
