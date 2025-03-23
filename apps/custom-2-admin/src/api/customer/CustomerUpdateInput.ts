import { AddressWhereUniqueInput } from "../address/AddressWhereUniqueInput";
import { MorUpdateManyWithoutCustomersInput } from "./MorUpdateManyWithoutCustomersInput";
import { OrderUpdateManyWithoutCustomersInput } from "./OrderUpdateManyWithoutCustomersInput";

export type CustomerUpdateInput = {
  address?: AddressWhereUniqueInput | null;
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  mors?: MorUpdateManyWithoutCustomersInput;
  orders?: OrderUpdateManyWithoutCustomersInput;
  phone?: string | null;
};
