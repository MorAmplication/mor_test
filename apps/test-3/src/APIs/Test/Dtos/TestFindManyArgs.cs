using Microsoft.AspNetCore.Mvc;
using Test_3.APIs.Common;
using Test_3.Infrastructure.Models;

namespace Test_3.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class TestFindManyArgs : FindManyInput<Test, TestWhereInput> { }
