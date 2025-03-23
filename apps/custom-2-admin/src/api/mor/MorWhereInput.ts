import { CustomerListRelationFilter } from "../customer/CustomerListRelationFilter";
import { StringFilter } from "../../util/StringFilter";

export type MorWhereInput = {
  customer?: CustomerListRelationFilter;
  id?: StringFilter;
};
