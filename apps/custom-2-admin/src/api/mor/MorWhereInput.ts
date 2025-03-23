import { StringFilter } from "../../util/StringFilter";
import { CustomerListRelationFilter } from "../customer/CustomerListRelationFilter";

export type MorWhereInput = {
  id?: StringFilter;
  customer?: CustomerListRelationFilter;
};
