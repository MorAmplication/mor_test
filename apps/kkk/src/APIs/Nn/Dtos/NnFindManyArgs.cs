using Kkk.APIs.Common;
using Kkk.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kkk.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class NnFindManyArgs : FindManyInput<Nn, NnWhereInput> { }
