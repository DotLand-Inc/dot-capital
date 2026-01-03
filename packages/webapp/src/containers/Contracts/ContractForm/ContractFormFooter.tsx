// @ts-nocheck
import React from 'react';
import { Button, Intent } from '@blueprintjs/core';
import { FormattedMessage as T } from '@/components';
import styled from 'styled-components';

/**
 * Contract form footer.
 */
export default function ContractFormFooter({ isSubmitting, onCancel }) {
  return (
    <FooterActions>
      <Button
        intent={Intent.PRIMARY}
        type="submit"
        loading={isSubmitting}
        text={<T id={'save'} />}
      />
      <Button
        onClick={onCancel}
        text={<T id={'cancel'} />}
      />
    </FooterActions>
  );
}

const FooterActions = styled.div`
  margin-top: 20px;

  .bp4-button {
    margin-right: 10px;
  }
`;
