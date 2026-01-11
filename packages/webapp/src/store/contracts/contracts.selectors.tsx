// @ts-nocheck
import { createSelector } from 'reselect';

const contractsTableStateSelector = (state) => state.contracts.tableState;
const contractsSelectedRowsSelector = (state) => state.contracts.selectedRows;

export const getContractsTableStateFactory = () =>
  createSelector(contractsTableStateSelector, (tableState) => tableState);

export const getContractsSelectedRowsFactory = () =>
  createSelector(contractsSelectedRowsSelector, (selectedRows) => selectedRows);
