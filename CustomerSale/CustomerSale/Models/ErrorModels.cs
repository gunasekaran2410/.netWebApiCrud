namespace CustomerSale.Models
{
    public class ErrorModels
    {
        public string error_status { get; set; }
        public string error_message { get; set; }

        public static async Task<ErrorModels> ErrorMessage(string status, string message)
        {
            ErrorModels error = new ErrorModels
            {
                error_status = status,
                error_message = message
            };
            return error;
        }
    }
}
