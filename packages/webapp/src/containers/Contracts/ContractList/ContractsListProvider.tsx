// @ts-nocheck
import React, { createContext, useContext } from 'react';

const ContractsListContext = createContext();

/**
 * Contracts list provider.
 */
function ContractsListProvider({ tableState, tableStateChanged, ...props }) {
  const provider = {
    contractsTableState: tableState,
    contractsTableStateChanged: tableStateChanged,
  };

  return (
    <ContractsListContext.Provider value={provider} {...props} />
  );
}

const useContractsListContext = () => useContext(ContractsListContext);

export { ContractsListProvider, useContractsListContext };
