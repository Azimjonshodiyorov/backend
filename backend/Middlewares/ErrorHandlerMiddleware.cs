namespace NetCoreDemo.Middlewares;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Helpers;

public class ErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
        await next(context);
        }
        catch (ServiceException e)
        {
        await context.Response.WriteAsJsonAsync(new
        {
            StatusCode = e.StatusCode,
            Message = e.Message
        });
        }
        catch (DbUpdateException e)
        {
        await context.Response.WriteAsJsonAsync(new
        {
            StatusCode = 500,
            Message = e.InnerException!.Message
        });
        }
        catch (Exception e)
        {
        await context.Response.WriteAsJsonAsync(new
        {
            StatusCode = 500,
            Message = e.Message
        });
        }
    }
}