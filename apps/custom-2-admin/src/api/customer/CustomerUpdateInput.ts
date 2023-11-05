import { OrderUpdateManyWithoutCustomersInput } from "./OrderUpdateManyWithoutCustomersInput";
import { AddressWhereUniqueInput } from "../address/AddressWhereUniqueInput";
import { MorUpdateManyWithoutCustomersInput } from "./MorUpdateManyWithoutCustomersInput";

export type CustomerUpdateInput = {
  firstName?: string | null;
  lastName?: string | null;
  email?: string | null;
  phone?: string | null;
  orders?: OrderUpdateManyWithoutCustomersInput;
  address?: AddressWhereUniqueInput | null;
  mors?: MorUpdateManyWithoutCustomersInput;
};
