// @ts-nocheck
import t from '@/store/types';

export const setContractsTableState = (queries) => {
  return {
    type: t.CONTRACTS_TABLE_STATE_SET,
    payload: { queries },
  };
};

export const resetContractsTableState = () => {
  return {
    type: t.CONTRACTS_TABLE_STATE_RESET,
  };
};

export const setContractsSelectedRows = (selectedRows) => {
  return {
    type: 'CONTRACTS/SET_SELECTED_ROWS',
    payload: selectedRows,
  };
};

export const resetContractsSelectedRows = () => {
  return {
    type: 'CONTRACTS/RESET_SELECTED_ROWS',
  };
};
