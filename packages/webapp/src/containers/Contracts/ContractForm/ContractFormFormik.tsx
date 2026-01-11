// @ts-nocheck
import React from 'react';
import { Formik, Form } from 'formik';
import { Intent } from '@blueprintjs/core';

import { AppToaster, FormattedMessage as T } from '@/components';
import { useContractFormContext } from './ContractFormProvider';

import ContractFormFields from './ContractFormFields';
import ContractFormFooter from './ContractFormFooter';

/**
 * Contract form formik.
 */
export default function ContractFormFormik({
  onSubmitSuccess,
  onCancel,
}) {
  const { contractId } = useContractFormContext();

  const initialValues = {
    name: '',
    description: '',
  };

  const handleSubmit = (values, { setSubmitting }) => {
    // Placeholder for submit logic
    console.log('Contract form submitted:', values);

    AppToaster.show({
      message: contractId
        ? 'Contract updated successfully'
        : 'Contract created successfully',
      intent: Intent.SUCCESS,
    });

    setSubmitting(false);
    onSubmitSuccess && onSubmitSuccess(values, {}, {});
  };

  return (
    <Formik
      initialValues={initialValues}
      onSubmit={handleSubmit}
    >
      {({ isSubmitting }) => (
        <Form>
          <ContractFormFields />
          <ContractFormFooter
            isSubmitting={isSubmitting}
            onCancel={onCancel}
          />
        </Form>
      )}
    </Formik>
  );
}
