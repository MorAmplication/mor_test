namespace Order.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class OrderFindMany : FindManyInput<Order, OrderWhereInput> { }
