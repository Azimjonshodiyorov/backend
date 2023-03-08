namespace NetCoreDemo.Controllers;

using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[Route("[controller]s")]
public abstract class ApiControllerBase : ControllerBase
{
}