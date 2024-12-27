﻿namespace VotingApplication.Response
{
    public class BaseResponse
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
    }

    public class BaseResponse<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public T? Data { get; set; }
    }
}
