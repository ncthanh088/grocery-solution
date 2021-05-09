namespace Grocery.Domain.Exceptions
{
    public class EntityInvalidException : System.Exception
    {
        public EntityInvalidException()
            : base("Entity not valid")
        {
        }

        public EntityInvalidException(string message)
            : base(message)
        {
        }
    }
}