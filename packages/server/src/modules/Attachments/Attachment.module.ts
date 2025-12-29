import { Module } from "@nestjs/common";
import * as multerS3 from 'multer-s3';
import { S3_CLIENT, S3Module } from "../S3/S3.module";
import { DeleteAttachment } from "./DeleteAttachment";
import { GetAttachment } from "./GetAttachment";
import { getAttachmentPresignedUrl } from "./GetAttachmentPresignedUrl";
import { LinkAttachment } from "./LinkAttachment";
import { UnlinkAttachment } from "./UnlinkAttachment";
import { ValidateAttachments } from "./ValidateAttachments";
import { AttachmentsOnBillPayments } from "./events/AttachmentsOnPaymentsMade";
import { AttachmentsOnBills } from "./events/AttachmentsOnBills";
import { AttachmentsOnCreditNote } from "./events/AttachmentsOnCreditNote";
import { AttachmentsOnExpenses } from "./events/AttachmentsOnExpenses";
import { AttachmentsOnPaymentsReceived } from "./events/AttachmentsOnPaymentsReceived";
import { AttachmentsOnManualJournals } from "./events/AttachmentsOnManualJournals";
import { AttachmentsOnVendorCredits } from "./events/AttachmentsOnVendorCredits";
import { AttachmentsOnSaleInvoiceCreated } from "./events/AttachmentsOnSaleInvoice";
import { AttachmentsController } from "./Attachments.controller";
import { RegisterTenancyModel } from "../Tenancy/TenancyModels/Tenancy.module";
import { DocumentModel } from "./models/Document.model";
import { DocumentLinkModel } from "./models/DocumentLink.model";
import { AttachmentsApplication } from "./AttachmentsApplication";
import { UploadDocument } from "./UploadDocument";
import { AttachmentUploadPipeline } from "./S3UploadPipeline";
import { MULTER_MODULE_OPTIONS } from "@/common/constants/files.constants";
import { ConfigService } from "@nestjs/config";
import { S3Client } from "@aws-sdk/client-s3";

const models = [
  RegisterTenancyModel(DocumentModel),
  RegisterTenancyModel(DocumentLinkModel),
];

@Module({
  imports: [S3Module, ...models],
  exports: [...models],
  controllers: [AttachmentsController],
  providers: [
    DeleteAttachment,
    GetAttachment,
    getAttachmentPresignedUrl,
    LinkAttachment,
    UnlinkAttachment,
    ValidateAttachments,
    AttachmentsOnBillPayments,
    AttachmentsOnBills,
    AttachmentsOnCreditNote,
    AttachmentsOnExpenses,
    AttachmentsOnPaymentsReceived,
    AttachmentsOnManualJournals,
    AttachmentsOnVendorCredits,
    AttachmentsOnSaleInvoiceCreated,
    AttachmentsApplication,
    UploadDocument,
    AttachmentUploadPipeline,
    {
      provide: MULTER_MODULE_OPTIONS,
      inject: [ConfigService, S3_CLIENT],
      useFactory: (configService: ConfigService, s3: S3Client) => {
        const s3Config = configService.get('s3');
        console.log('[S3 Upload] Multer-S3 configuration:', {
          bucket: s3Config.bucket,
          region: s3Config.region,
          endpoint: s3Config.endpoint,
          forcePathStyle: s3Config.forcePathStyle,
          hasAccessKey: !!s3Config.accessKeyId,
          hasSecretKey: !!s3Config.secretAccessKey,
        });

        return {
          storage: multerS3({
            s3,
            bucket: s3Config.bucket,
            contentType: multerS3.AUTO_CONTENT_TYPE,
            metadata: function (req, file, cb) {
              console.log('[S3 Upload] Setting metadata for file:', {
                originalname: file.originalname,
                mimetype: file.mimetype,
              });
              cb(null, { fieldName: file.fieldname });
            },
            key: function (req, file, cb) {
              const key = Date.now().toString();
              console.log('[S3 Upload] Generated S3 key:', {
                key,
                originalname: file.originalname,
                bucket: s3Config.bucket,
              });
              cb(null, key);
            },
            acl: function(req, file, cb) {
              // Conditionally set file to public or private based on isPublic flag
              const aclValue = true ? 'public-read' : 'private';
              console.log('[S3 Upload] Setting ACL:', { acl: aclValue });
              // Set ACL based on the isPublic flag
              cb(null, aclValue);
            }
          }),
        };
      }
    }
  ]
})
export class AttachmentsModule {}