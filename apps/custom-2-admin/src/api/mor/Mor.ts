import { Customer } from "../customer/Customer";

export type Mor = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  customer?: Array<Customer>;
};
