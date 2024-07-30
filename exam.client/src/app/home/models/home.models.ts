import { Upload } from "../../shared/models/shared.model";

export type UploadList = {
  list: Upload[],
  total: number
};