import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";
import HttpApi from "i18next-http-backend";
import { initReactI18next } from 'react-i18next';
import translationEN from "./en/translation.json";
import translationFR from "./fr/translation.json";
// import commonEN from "./en/common.json";
// import commonFR from "./fr/common.json";
// import validationEN from "./en/validation.json";
// import validationFR from "./fr/validation.json";

// the translations
const resources = {
    en: {
        translation: translationEN,
        // common: commonEN,
        // validation: validationEN
    },
    fr: {
        translation: translationFR,
        // common: commonFR,
        // validation: validationFR
    },
};

i18n
    .use(HttpApi)
    .use(LanguageDetector)
    .use(initReactI18next) // passes i18n down to react-i18next
    .init({
        debug: true,
        detection: {
            order: ['cookie', 'navigator', 'localStorage']
        },
        load: 'languageOnly', //language codes to lookup

        fallbackLng: 'en', // use en if detected lng is not available

        react: {
            useSuspense: false
        },

        interpolation: {
            escapeValue: false, // react already safes from xss
            format: function (value, format, lng) {
                if (format === 'uppercase') return value.toUpperCase();
                if (format === 'lowercase') return value.toLowerCase();
                return value;
            }
        },
        resources,
        ns: ["common", "validation", "translation"],
        defaultNS: "translation",
    });

export default i18n;
