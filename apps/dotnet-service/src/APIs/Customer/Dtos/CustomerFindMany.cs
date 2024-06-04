using DotnetService.APIs.Common;
using DotnetService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindMany : FindManyInput<Customer, CustomerWhereInput> { }
