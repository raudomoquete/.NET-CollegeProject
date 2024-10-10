namespace College.API.Exception.ExceptionClasses
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
