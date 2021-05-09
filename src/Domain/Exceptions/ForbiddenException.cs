namespace Grocery.Domain.Exceptions
{
    public class ForbiddenException : System.Exception
    {
        public ForbiddenException()
            : base("Forbidden access features")
        {
        }
    }
}