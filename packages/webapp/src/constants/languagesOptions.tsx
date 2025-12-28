// @ts-nocheck
import intl from 'react-intl-universal';

export const getLanguages = () => [
  { name: intl.get('english'), value: 'en' },
  { name: intl.get('arabic'), value: 'ar' },
  { name: intl.get('french'), value: 'fr' },
  { name: intl.get('german'), value: 'de' },
  { name: intl.get('spanish'), value: 'es' },
];
