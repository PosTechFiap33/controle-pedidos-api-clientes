﻿using Microsoft.Extensions.Logging;
using Refit;

namespace CP.Clientes.Payment.Extensions;

public static class LoggerExtensions
{
    public static void LogApiError(this ILogger logger, ApiException exception, string message)
    {
        logger.LogError(exception, message + ": {StatusCode} - {ReasonPhrase} - Response Body: {ResponseBody}.", exception.StatusCode, exception.ReasonPhrase, exception.Content);
    }
}
