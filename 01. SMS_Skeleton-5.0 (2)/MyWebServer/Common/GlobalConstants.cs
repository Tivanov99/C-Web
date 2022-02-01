namespace MyWebServer.Common
{
    public static class GlobalConstants
    {
        public const int usernameMinLength = 5;
        public const int usernameMaxLength = 20;

        public const int passwordMinLength = 6;
        public const int passwordMaxLength = 20;


        public const int productNameMinLength = 4;
        public const int productNameMaxLength = 20;


        public const decimal productMinPrice = (decimal)0.05;
        public const decimal productMaxPrice = 1000;

        public const string emailValidationTemplate = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
