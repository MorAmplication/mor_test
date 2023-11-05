import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { OrderListRelationFilter } from "../order/OrderListRelationFilter";
import { AddressWhereUniqueInput } from "../address/AddressWhereUniqueInput";
import { MorListRelationFilter } from "../mor/MorListRelationFilter";

export type CustomerWhereInput = {
  id?: StringFilter;
  firstName?: StringNullableFilter;
  lastName?: StringNullableFilter;
  email?: StringNullableFilter;
  phone?: StringNullableFilter;
  orders?: OrderListRelationFilter;
  address?: AddressWhereUniqueInput;
  mors?: MorListRelationFilter;
};
