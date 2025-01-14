﻿using AviaTicket.Helpers;

namespace AviaTicket.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
            });
        }
    }
}
