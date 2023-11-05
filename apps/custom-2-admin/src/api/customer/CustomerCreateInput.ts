import { OrderCreateNestedManyWithoutCustomersInput } from "./OrderCreateNestedManyWithoutCustomersInput";
import { AddressWhereUniqueInput } from "../address/AddressWhereUniqueInput";
import { MorCreateNestedManyWithoutCustomersInput } from "./MorCreateNestedManyWithoutCustomersInput";

export type CustomerCreateInput = {
  firstName?: string | null;
  lastName?: string | null;
  email?: string | null;
  phone?: string | null;
  orders?: OrderCreateNestedManyWithoutCustomersInput;
  address?: AddressWhereUniqueInput | null;
  mors?: MorCreateNestedManyWithoutCustomersInput;
};
