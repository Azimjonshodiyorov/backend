namespace NetCoreDemo.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

public class ServiceException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }

    public ServiceException(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public static ServiceException NotFound(string message = "Id is not found")
    {
        return new ServiceException(HttpStatusCode.NotFound, message);
    }

    public static ServiceException Unauthorized(string message = "Unauthorized")
    {
        return new ServiceException(HttpStatusCode.Unauthorized, message);
    }

    public static ServiceException BadRequest(string message = "Bad request")
    {
        return new ServiceException(HttpStatusCode.BadRequest, message);
    }
}
