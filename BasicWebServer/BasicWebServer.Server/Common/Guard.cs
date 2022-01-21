namespace BasicWebServer.Server.Common
{
    using System;

    public static class Guard
    {
        public static void AgainstNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "name";
                throw new ArgumentException($"{name} cannot be null");
            }
        }
    }
}
