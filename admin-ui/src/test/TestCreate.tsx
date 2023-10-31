import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const TestCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="gihio" source="gihio" />
      </SimpleForm>
    </Create>
  );
};
