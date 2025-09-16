namespace E_Commerce.API.Helper
{
    public class ResponsAPI
    {
        public ResponsAPI(int statusCode, string? message = null)
        {
            StatusCodes = statusCode;
            Message = message ?? CreateResponse(StatusCodes);
        }

        public int StatusCodes { get; set; }
        public string? Message { get; set; }

        private string CreateResponse(int statusCodem)
        {
            return statusCodem switch
            {
                200 => "Ok",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"
            };
        }
    }
}
