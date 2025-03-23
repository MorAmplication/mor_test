import { AddressWhereUniqueInput } from "../address/AddressWhereUniqueInput";
import { MorCreateNestedManyWithoutCustomersInput } from "./MorCreateNestedManyWithoutCustomersInput";
import { OrderCreateNestedManyWithoutCustomersInput } from "./OrderCreateNestedManyWithoutCustomersInput";

export type CustomerCreateInput = {
  address?: AddressWhereUniqueInput | null;
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  mors?: MorCreateNestedManyWithoutCustomersInput;
  orders?: OrderCreateNestedManyWithoutCustomersInput;
  phone?: string | null;
};
