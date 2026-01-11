// @ts-nocheck
import React, { createContext, useContext } from 'react';

const ContractFormContext = createContext();

/**
 * Contract form provider.
 */
function ContractFormProvider({ contractId, ...props }) {
  const provider = {
    contractId,
    isFormLoading: false,
  };

  return (
    <ContractFormContext.Provider value={provider} {...props} />
  );
}

const useContractFormContext = () => useContext(ContractFormContext);

export { ContractFormProvider, useContractFormContext };
