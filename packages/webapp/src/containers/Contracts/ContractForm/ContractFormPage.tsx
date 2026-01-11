// @ts-nocheck
import React from 'react';
import { useParams, useHistory } from 'react-router-dom';

import { DashboardCard, DashboardInsider } from '@/components';

import ContractFormFormik from './ContractFormFormik';
import {
  ContractFormProvider,
  useContractFormContext,
} from './ContractFormProvider';

/**
 * Contract form page loading.
 * @returns {JSX}
 */
function ContractFormPageLoading({ children }) {
  const { isFormLoading } = useContractFormContext();

  return (
    <DashboardInsider loading={isFormLoading}>
      {children}
    </DashboardInsider>
  );
}

/**
 * Contract form page.
 * @returns {JSX}
 */
export default function ContractFormPage() {
  const history = useHistory();
  const { id } = useParams();

  const contractId = parseInt(id, 10);

  // Handle the form submit success.
  const handleSubmitSuccess = (values, formArgs, submitPayload) => {
    if (!submitPayload.noRedirect) {
      history.push('/contracts');
    }
  };
  // Handle the form cancel button click.
  const handleFormCancel = () => {
    history.goBack();
  };

  return (
    <ContractFormProvider contractId={contractId}>
      <ContractFormPageLoading>
        <DashboardCard page>
          <ContractFormFormik
            onSubmitSuccess={handleSubmitSuccess}
            onCancel={handleFormCancel}
          />
        </DashboardCard>
      </ContractFormPageLoading>
    </ContractFormProvider>
  );
}
