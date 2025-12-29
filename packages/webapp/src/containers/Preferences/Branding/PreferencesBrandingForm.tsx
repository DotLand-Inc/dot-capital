import React, { CSSProperties } from 'react';
import { Formik, Form, FormikHelpers } from 'formik';
import * as Yup from 'yup';
import { omit } from 'lodash';
import { PreferencesBrandingFormValues } from './_types';
import { useUploadAttachments } from '@/hooks/query/attachments';
import { AppToaster } from '@/components';
import { Intent } from '@blueprintjs/core';
import {
  excludePrivateProps,
  transformToCamelCase,
  transformToForm,
  transfromToSnakeCase,
} from '@/utils';
import { useUpdateOrganization } from '@/hooks/query';
import { usePreferencesBrandingBoot } from './PreferencesBrandingBoot';

const initialValues = {
  logoKey: '',
  logoUri: '',
  primaryColor: '',
};

const validationSchema = Yup.object({
  logoKey: Yup.string().optional(),
  logoUri: Yup.string().optional(),
  primaryColor: Yup.string().required('Primary color is required'),
});

interface PreferencesBrandingFormProps {
  children: React.ReactNode;
}

export const PreferencesBrandingForm = ({
  children,
}: PreferencesBrandingFormProps) => {
  // Uploads the attachments.
  const { mutateAsync: uploadAttachments } = useUploadAttachments({});
  // Mutate organization information.
  const { mutateAsync: updateOrganization } = useUpdateOrganization();

  const { organization } = usePreferencesBrandingBoot();

  const formInitialValues = {
    ...transformToForm(
      transformToCamelCase(organization?.metadata),
      initialValues,
    ),
  } as PreferencesBrandingFormValues;

  // Handle the form submitting.
  const handleSubmit = async (
    values: PreferencesBrandingFormValues,
    { setSubmitting }: FormikHelpers<PreferencesBrandingFormValues>,
  ) => {
    console.log('[Frontend Logo Upload] Starting form submission:', {
      hasLogoFile: !!values._logoFile,
      fileName: values._logoFile?.name,
      fileSize: values._logoFile?.size,
      fileType: values._logoFile?.type,
      currentLogoKey: values.logoKey,
    });

    const _values = { ...values };

    const handleError = (message: string) => {
      console.error('[Frontend Logo Upload] Error:', message);
      AppToaster.show({ intent: Intent.DANGER, message });
      setSubmitting(false);
    };
    // Start upload the company logo file if it is presented.
    if (values._logoFile) {
      console.log('[Frontend Logo Upload] Preparing FormData for upload...');
      const formData = new FormData();
      const key = Date.now().toString();

      formData.append('file', values._logoFile);
      formData.append('internalKey', key);

      console.log('[Frontend Logo Upload] Sending upload request to /api/attachments');

      try {
        // @ts-expect-error
        const uploadedAttachmentRes = await uploadAttachments(formData);
        console.log('[Frontend Logo Upload] Upload response received:', {
          key: uploadedAttachmentRes?.key,
          id: uploadedAttachmentRes?.id,
          fullResponse: uploadedAttachmentRes,
        });
        setSubmitting(false);

        // Adds the attachment key to the values after finishing upload.
        _values['logoKey'] = uploadedAttachmentRes?.key;
        console.log('[Frontend Logo Upload] Logo key set to values:', {
          logoKey: _values['logoKey'],
        });
      } catch (error) {
        console.error('[Frontend Logo Upload] Upload failed:', error);
        handleError('An error occurred while uploading company logo.');
        setSubmitting(false);
        return;
      }
    }
    // Exclude all the private props that starts with _.
    const excludedPrivateValues = excludePrivateProps(_values);

    const __values = transfromToSnakeCase(
      omit(excludedPrivateValues, ['logoUri']),
    );

    console.log('[Frontend Logo Upload] Updating organization with values:', {
      logoKey: __values.logo_key,
      primaryColor: __values.primary_color,
    });

    // Update organization branding.
    // @ts-expect-error
    await updateOrganization({ ...__values });

    console.log('[Frontend Logo Upload] Organization updated successfully');

    AppToaster.show({
      message: 'Organization branding has been updated.',
      intent: Intent.SUCCESS,
    });
  };

  return (
    <Formik
      initialValues={formInitialValues}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      <Form style={formStyle}>{children}</Form>
    </Formik>
  );
};

const formStyle: CSSProperties = {
  display: 'flex',
  flexDirection: 'column',
  flex: 1,
};
