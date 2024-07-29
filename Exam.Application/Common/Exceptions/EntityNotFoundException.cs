namespace Exam.Application.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType, object key)
            : base($"Entity of type {entityType.Name} with key {key} was not found.")
        {
        }
    }
}
