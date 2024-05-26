// import logo from './logo.svg';
import { IntlProvider } from 'react-intl'
import { I18nextProvider } from 'react-i18next';
import i18n from './locales/i18n';
import { NotificationContainer } from 'react-notifications';
import AppRouter from './routes';
import './App.css';


function App() {
  return (
        <>

        <IntlProvider locale="en">
          <I18nextProvider i18n={i18n}>
            <AppRouter />
          </I18nextProvider>
        </IntlProvider>
        <NotificationContainer />
        </>
  );
}

export default App;
