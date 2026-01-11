// @ts-nocheck
import { connect } from 'react-redux';
import { getContractsTableStateFactory } from '@/store/contracts/contracts.selectors';

export const mapStateToProps = (state, props) => {
  const getContractsTableState = getContractsTableStateFactory();

  return {
    contractsTableState: getContractsTableState(state, props),
  };
};

export default connect(mapStateToProps);
