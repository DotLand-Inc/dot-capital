// @ts-nocheck
import React from 'react';
import { useContractsListContext } from './ContractsListProvider';

/**
 * Contracts table.
 */
export default function ContractsTable() {
  const { contractsTableState } = useContractsListContext();

  return (
    <div>
      <p>Contracts table placeholder</p>
    </div>
  );
}
