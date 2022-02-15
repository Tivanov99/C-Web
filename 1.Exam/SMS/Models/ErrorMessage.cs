namespace SMS.Models
{
    public class ErrorMessage
    {
        public ErrorMessage(string errorMessage)
        {
            this.ErrorText = errorMessage;
        }
        public string ErrorText { get; set; }
    }
}
