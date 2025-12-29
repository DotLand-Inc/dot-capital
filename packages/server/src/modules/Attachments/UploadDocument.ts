import { Inject, Injectable } from '@nestjs/common';
import { TenancyDatabaseModule } from '../Tenancy/TenancyDB/TenancyDB.module';
import { TenantModelProxy } from '../System/models/TenantBaseModel';
import { DocumentModel } from './models/Document.model';

@Injectable()
export class UploadDocument {
  constructor(
    @Inject(DocumentModel.name)
    private readonly documentModel: TenantModelProxy<typeof DocumentModel>,
  ) {}

  /**
   * Inserts the document metadata.
   * @param {number} tenantId
   * @param {} file
   * @returns {}
   */
  async upload(file: any) {
    console.log('[S3 Upload] Saving document metadata to database:', {
      key: file.key,
      mimeType: file.mimetype,
      size: file.size,
      originName: file.originalname,
    });

    const insertedDocument = await this.documentModel().query().insert({
      key: file.key,
      mimeType: file.mimetype,
      size: file.size,
      originName: file.originalname,
    });

    console.log('[S3 Upload] Document metadata saved:', {
      id: insertedDocument.id,
      key: insertedDocument.key,
    });

    return insertedDocument;
  }
}
