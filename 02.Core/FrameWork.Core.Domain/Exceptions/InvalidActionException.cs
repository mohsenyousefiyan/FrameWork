using System;

namespace FrameWork.Core.Domain.Exceptions
{
    [Serializable]
    public class InvalidActionException : BaseException
    {
        public InvalidActionException(string message) : base(message)
        {
        }
    }
}
