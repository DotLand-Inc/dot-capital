// @ts-nocheck
import React from 'react';
import { FFormGroup, FInputGroup, FTextArea, FormattedMessage as T } from '@/components';

/**
 * Contract form fields.
 */
export default function ContractFormFields() {
  return (
    <div>
      <FFormGroup
        name={'name'}
        label={<T id={'contract_name'} />}
      >
        <FInputGroup name={'name'} />
      </FFormGroup>

      <FFormGroup
        name={'description'}
        label={<T id={'description'} />}
      >
        <FTextArea name={'description'} growVertically={true} />
      </FFormGroup>
    </div>
  );
}
