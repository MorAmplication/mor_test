namespace Product.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ProductFindMany : FindManyInput<Product, ProductWhereInput> { }
