using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string errorMessage)
        {
            this.ErrorMessage = errorMessage;   
        }
        public string ErrorMessage { get; set; }
    }
}
