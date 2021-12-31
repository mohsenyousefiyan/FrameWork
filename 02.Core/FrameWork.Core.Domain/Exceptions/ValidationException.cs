using System;

namespace FrameWork.Core.Domain.Exceptions
{
    [Serializable]
    public class ValidationException : BaseException
    {

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public string EntityName { get; }
        public ValidationException(object entity, string message) : base(message)
        {
            EntityName = entity.GetType().Name;
        }
    }
}
