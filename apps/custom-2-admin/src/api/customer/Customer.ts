import { Order } from "../order/Order";
import { Address } from "../address/Address";
import { Mor } from "../mor/Mor";

export type Customer = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  firstName: string | null;
  lastName: string | null;
  email: string | null;
  phone: string | null;
  orders?: Array<Order>;
  address?: Address | null;
  mors?: Array<Mor>;
};
