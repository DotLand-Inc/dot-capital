// @ts-nocheck
import React, { useEffect } from 'react';

import { DashboardPageContent } from '@/components';

import ContractsActionsBar from './ContractsActionsBar';
import ContractsTable from './ContractsTable';
import { ContractsListProvider } from './ContractsListProvider';

import withContracts from './withContracts';
import withContractsActions from './withContractsActions';

import { compose } from '@/utils';

/**
 * Contracts list.
 */
function ContractsList({
  // #withContracts
  contractsTableState,
  contractsTableStateChanged,

  // #withContractsActions
  resetContractsTableState,
  resetContractsSelectedRows,
}) {
  // Resets the contracts table state once the page unmount.
  useEffect(
    () => () => {
      resetContractsTableState();
      resetContractsSelectedRows();
    },
    [resetContractsSelectedRows, resetContractsTableState],
  );

  return (
    <ContractsListProvider
      tableState={contractsTableState}
      tableStateChanged={contractsTableStateChanged}
    >
      <ContractsActionsBar />

      <DashboardPageContent>
        <ContractsTable />
      </DashboardPageContent>
    </ContractsListProvider>
  );
}

export default compose(
  withContractsActions,
  withContracts,
)(ContractsList);
