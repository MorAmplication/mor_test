using Microsoft.AspNetCore.Mvc;
using OrderManagementDotNet.APIs.Common;
using OrderManagementDotNet.Infrastructure.Models;

namespace OrderManagementDotNet.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ProductFindMany : FindManyInput<Product, ProductWhereInput> { }
