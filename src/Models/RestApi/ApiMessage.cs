﻿using System;
using System.Net;

namespace Sky.Models.RestApi
{
    public class ApiMessage
    {
        public String PathAndQuery { get; set; }

        public DateTime? RequestTime { get; set; }

        public HttpStatusCode ResponseStatus { get; set; }
        public Exception ResponseException { get; set; }
    }
    public class ApiMessage<TResponse> : ApiMessage
    {
        public TResponse ResponseObject { get; set; }
    }
}
