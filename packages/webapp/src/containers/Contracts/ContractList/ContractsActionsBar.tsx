// @ts-nocheck
import React from 'react';
import {
  Button,
  NavbarGroup,
  Classes,
  NavbarDivider,
} from '@blueprintjs/core';
import { useHistory } from 'react-router-dom';

import { DashboardActionsBar, Icon, FormattedMessage as T } from '@/components';

/**
 * Contracts actions bar.
 */
export default function ContractsActionsBar() {
  const history = useHistory();

  const handleNewContractClick = () => {
    history.push('/contracts/new');
  };

  return (
    <DashboardActionsBar>
      <NavbarGroup>
        <Button
          className={Classes.MINIMAL}
          icon={<Icon icon="plus" />}
          text={<T id={'new_contract'} />}
          onClick={handleNewContractClick}
        />
        <NavbarDivider />
      </NavbarGroup>
    </DashboardActionsBar>
  );
}
