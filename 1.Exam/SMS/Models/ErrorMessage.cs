namespace SMS.Models
{
    public class ErrorMessage
    {
        public ErrorMessage(string errorMessage)
        {
            this.Error = errorMessage;
        }
        public string Error { get; set; }
    }
}
