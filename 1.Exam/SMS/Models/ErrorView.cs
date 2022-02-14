namespace SMS.Models
{
    using System.Collections.Generic;

    public class ErrorView
    {
        public ErrorView()
        {
            this.Errors = new();
        }
        public List<ErrorViewModel> Errors { get; set; }
    }
}
