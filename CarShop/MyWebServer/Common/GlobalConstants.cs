namespace MyWebServer.Common
{
    public static class GlobalConstants
    {
        public const int UsernameMinLength = 4;
        public const int UsernameMaxLength = 20;

        public const int PassworMinLength = 5;
        public const int PassworMaxLength = 20;

        public const int CarModelMinLength = 5;
        public const int CarModelMaxLength = 20;

        public const int IssueDescriptionMinLength = 5;

        public const string EmailValidationTemplate = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
