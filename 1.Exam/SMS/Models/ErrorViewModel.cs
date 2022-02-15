namespace SMS.Models
{
    using System.Collections.Generic;

    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
            this.Errors = new();
        }
        public List<ErrorMessage> Errors { get; set; }
    }
}
