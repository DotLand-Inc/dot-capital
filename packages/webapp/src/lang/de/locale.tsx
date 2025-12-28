// @ts-nocheck
import printValue from '../printValue';

export const locale = {
  mixed: {
    default: '${path} ist ungültig',
    required: '${path} ist ein Pflichtfeld',
    oneOf: '${path} muss einer der folgenden Werte sein: ${values}',
    notOneOf: '${path} darf keiner der folgenden Werte sein: ${values}',
    notType: ({ path, type, value, originalValue }) => {
      let isCast = originalValue != null && originalValue !== value;
      let msg =
        `${path} muss vom Typ \`${type}\` sein, ` +
        `aber der endgültige Wert war: \`${printValue(value, true)}\`` +
        (isCast
          ? ` (konvertiert vom Wert \`${printValue(originalValue, true)}\`).`
          : '.');

      if (value === null) {
        msg += `\n Wenn "null" als leerer Wert beabsichtigt ist, stellen Sie sicher, dass das Schema als \`.nullable()\` markiert ist`;
      }

      return msg;
    },
    defined: '${path} muss definiert sein',
  },
  string: {
    length: '${path} muss genau ${length} Zeichen lang sein',
    min: '${path} muss mindestens ${min} Zeichen lang sein',
    max: '${path} darf höchstens ${max} Zeichen lang sein',
    matches: '${path} muss dem folgenden Format entsprechen: "${regex}"',
    email: '${path} muss eine gültige E-Mail-Adresse sein',
    url: '${path} muss eine gültige URL sein',
    trim: '${path} muss eine Zeichenkette ohne Leerzeichen sein',
    lowercase: '${path} muss eine Zeichenkette in Kleinbuchstaben sein',
    uppercase: '${path} muss eine Zeichenkette in Großbuchstaben sein',
  },
  number: {
    min: '${path} muss größer oder gleich ${min} sein',
    max: '${path} muss kleiner oder gleich ${max} sein',
    lessThan: '${path} muss kleiner als ${less} sein',
    moreThan: '${path} muss größer als ${more} sein',
    notEqual: '${path} darf nicht gleich ${notEqual} sein',
    positive: '${path} muss eine positive Zahl sein',
    negative: '${path} muss eine negative Zahl sein',
    integer: '${path} muss eine ganze Zahl sein',
  },
  date: {
    min: '${path} muss nach ${min} liegen',
    max: '${path} muss vor ${max} liegen',
  },
  boolean: {},
  object: {
    noUnknown:
      '${path} darf keine nicht spezifizierten Schlüssel in der Objektform haben',
  },
  array: {
    min: '${path} muss mindestens ${min} Elemente enthalten',
    max: '${path} darf höchstens ${max} Elemente enthalten',
  },
};
