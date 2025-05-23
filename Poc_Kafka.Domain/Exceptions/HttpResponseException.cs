﻿namespace Poc_Kafka.Domain.Exceptions;

public class HttpResponseException : Exception
{
    public HttpResponseException(string message) : base(message)
    {
    }
    public HttpResponseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
