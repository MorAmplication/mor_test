import { SortOrder } from "../../util/SortOrder";

export type TestEntityOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
};
