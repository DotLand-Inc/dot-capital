// @ts-nocheck
import { connect } from 'react-redux';
import { resetContractsTableState } from '@/store/contracts/contracts.actions';

export const mapDispatchToProps = (dispatch) => ({
  resetContractsTableState: () => dispatch(resetContractsTableState()),
  resetContractsSelectedRows: () => {
    // Placeholder for reset selected rows action
  },
});

export default connect(null, mapDispatchToProps);
