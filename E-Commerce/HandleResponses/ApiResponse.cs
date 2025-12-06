namespace E_Commerce.HandleResponses
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int code,string Msg=null)
        {
            StatusCode = code;
            Message = Msg??GetDefaultMessage(code);
        }

        private string GetDefaultMessage(int code) {
            return code switch{
                400=>"Bad Request",
                401=>"You are not authorized",
                404=>"Resourse not found",
                500=>"Internal Server Error",
                _=>null
            };
        }

    }
}
