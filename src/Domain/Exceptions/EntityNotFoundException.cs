namespace Grocery.Domain.Exceptions
{
    public class EntityNotFoundException : System.Exception
    {
        public EntityNotFoundException()
            : base("Entity not found")
        {
        }

        public EntityNotFoundException(string entityName, object keyValue)
            : base($"{entityName} not found by key {keyValue}.")
        {
        }
    }
}