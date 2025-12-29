// @ts-nocheck
import React from 'react';
import intl from 'react-intl-universal';
import { ControlGroup } from '@blueprintjs/core';
import { FormattedMessage as T, FFormGroup, FInputGroup } from '@/components';

export default function CustomerFormAfterPrimarySection({}) {
  return (
    <div className={'customer-form__after-primary-section-content'}>
      {/*------------ Customer email -----------*/}
      <FFormGroup
        name={'email'}
        label={<T id={'customer_email'} />}
        inline={true}
      >
        <FInputGroup
          name={'email'}
          type="email"
          autoCapitalize="off"
          autoCorrect="off"
        />
      </FFormGroup>

      {/*------------ Phone number -----------*/}
      <FFormGroup
        name={'personal_phone'}
        label={<T id={'phone_number'} />}
        inline={true}
      >
        <ControlGroup>
          <FInputGroup
            name={'personal_phone'}
            placeholder={intl.get('personal')}
            type="tel"
          />
          <FInputGroup
            name={'work_phone'}
            placeholder={intl.get('work')}
            type="tel"
          />
        </ControlGroup>
      </FFormGroup>

      {/*------------ Customer website -----------*/}
      <FFormGroup name={'website'} label={<T id={'website'} />} inline={true}>
        <FInputGroup
          name={'website'}
          placeholder={'http://'}
          type="url"
          autoCapitalize="off"
          autoCorrect="off"
        />
      </FFormGroup>
    </div>
  );
}
