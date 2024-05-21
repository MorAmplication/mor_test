namespace Address.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class AddressFindMany : FindManyInput<Address, AddressWhereInput> { }
