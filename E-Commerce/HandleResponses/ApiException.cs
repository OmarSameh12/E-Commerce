namespace E_Commerce.HandleResponses
{
    public class ApiException : ApiResponse
    {
        public ApiException(int code, string Msg = null, string details = null) : base(code, Msg)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
