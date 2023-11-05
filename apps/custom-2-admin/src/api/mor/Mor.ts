import { Customer } from "../customer/Customer";

export type Mor = {
  createdAt: Date;
  customer?: Array<Customer>;
  id: string;
  updatedAt: Date;
};
