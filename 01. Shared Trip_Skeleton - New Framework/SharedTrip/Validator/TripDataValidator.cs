using MyWebServer.Common;
using SharedTrip.ApplicationModels;

namespace SharedTrip.Validator
{
    public class TripDataValidator
    {
        public bool IsValidProduct(ICreateTripForm tripForm)
        {
            if (!IsValidTipName(tripForm.StartPoint))
            {
                return false;
            }

            if (!IsValidTripEndPoint(tripForm.EndPoint))
            {
                return false;
            }

            if (!IsValidImagePath(tripForm.ImagePath))
            {
                return false;
            }

            if (!IsValidSeatsCount(tripForm.Seats))
            {
                return false;
            }

            if (!IsValidTripDescription(tripForm.Description))
            {
                return false;
            }

            return true;
        }

        private bool IsValidTipName(string startPoint)
        {
            return !string.IsNullOrEmpty(startPoint);
        }
        private bool IsValidTripEndPoint(string endPoint)
        {
            return !string.IsNullOrEmpty(endPoint);
        }
        private bool IsValidImagePath(string imgPath)
        {
            return !string.IsNullOrEmpty(imgPath);
        }

        private bool IsValidSeatsCount(int seatsCount)
        {
            return GlobalConstants.SeatsMaxValue <= seatsCount &&
                GlobalConstants.SeatsMinValue >= seatsCount;
        }

        private bool IsValidTripDescription(string tripDescription)
        {
            return tripDescription.Length <= GlobalConstants.TripDescriptionMaxLength &&
                !string.IsNullOrEmpty(tripDescription);
        }
    }
}
