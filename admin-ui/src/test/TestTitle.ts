import { Test as TTest } from "../api/test/Test";

export const TEST_TITLE_FIELD = "gihio";

export const TestTitle = (record: TTest): string => {
  return record.gihio?.toString() || String(record.id);
};
