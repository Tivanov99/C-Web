using CarShop.DataForms;
using MyWebServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Validator
{
    public class CarDataValidator
    {
        public bool ValidateCarData(AddCarDataForm dataForm)
        {
            if (dataForm.Year <= 0)
            {
                return false;
            }
            if (!ModelIsValid(dataForm.Model))
            {
                return false;
            }
            if (!ModelIsValid(dataForm.Image))
            {
                return false;
            }
            if (!ImageIsValid(dataForm.Image))
            {
                return false;
            }
            return true;
        }
        private bool ModelIsValid(string model)
         => model.Length >= GlobalConstants.ModelMinLength &&
            model.Length <= GlobalConstants.ModelMaxLength;

        private bool ImageIsValid(string image)
        => image.Length > 0;
    }
}
